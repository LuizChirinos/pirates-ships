using UnityEngine;

namespace PiratesShip.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D rb;

        [SerializeField] private MovementData movementData;

        private void OnEnable()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * movementData.Speed;
        }
    }
}
