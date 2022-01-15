using PiratesShip.Inputs;
using UnityEngine;

namespace PiratesShip.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EntityMovement : MonoBehaviour
    {
        [SerializeField] private MovementData movementData;
        private BaseInput baseInput;
        private Rigidbody2D rb;

        public virtual Vector2 CurrentSpeed { get; private set; }

        #region Monobehaviour callbacks
        protected virtual void Start()
        {
            baseInput = GetComponent<BaseInput>();
            rb = GetComponent<Rigidbody2D>();
        }
        protected virtual void Update()
        {
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
    }

}