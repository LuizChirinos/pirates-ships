using UnityEngine;
using PiratesShip.Tags;

namespace PiratesShip.Life
{
    public class DamagerEntity : MonoBehaviour
    {
        [SerializeField] protected TagData targetTag;
        [SerializeField] private float damageAmount = 1f;

        public virtual float DamageAmount { get => damageAmount; }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Health health))
                return;
            if (!other.TryGetComponent(out EntityTag entityTag))
                return;
            if (entityTag != targetTag)
                return;

            health.Damage(damageAmount);
        }
    }
}
