using PiratesShip.Inputs;
using UnityEngine;

namespace PiratesShip.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EntityMovement : MonoBehaviour
    {
        #region Fields
        [SerializeField] private MovementData movementData;
        protected BaseInput baseInput;
        protected Rigidbody2D rb;
        protected int movementLock = 0;
        #endregion

        #region Properties
        public virtual Vector2 CurrentSpeed { get; private set; }
        public virtual bool CanMove { get => movementLock <= 0; }
        #endregion

        #region Monobehaviour callbacks
        protected virtual void Start()
        {
            baseInput = GetComponent<BaseInput>();
            rb = GetComponent<Rigidbody2D>();
        }
        protected virtual void Update()
        {
            if (!CanMove)
            {
                StopMove();
                return;
            }

            Move();
        }
        #endregion

        protected virtual Vector2 Move()
        {
            CurrentSpeed = baseInput.Direction * movementData.Speed;
            rb.velocity = CurrentSpeed;

            float angle = Mathf.Atan2(baseInput.Direction.y, baseInput.Direction.x) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(Vector3.forward * angle);
            if (baseInput.Direction.magnitude > 0)
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * movementData.RotationSpeed);

            return CurrentSpeed;
        }
        protected virtual void StopMove()
        {
            CurrentSpeed = Vector2.zero;
            rb.velocity = CurrentSpeed;
        }

        #region Public methods
        public void LockMovement()
        {
            movementLock++;
        }
        public void UnlockMovement()
        {
            movementLock--;
        }
        public void UnlockAllMovement()
        {
            movementLock = 0;
        }
        #endregion
    }

}