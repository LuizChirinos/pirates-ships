using UnityEngine;
using PiratesShip.Tags;

namespace PiratesShip.Damages
{
    public class DamagerEntity : MonoBehaviour
    {
        [SerializeField] protected TagData targetTagData;
        [SerializeField] private float damageAmount = 1f;
        [SerializeField] private bool disappearsOnCollision = true;

        public virtual float DamageAmount { get => damageAmount; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Health health))
                return;
            if (!other.TryGetComponent(out EntityTag entityTag))
                return;
            if (entityTag.TagData != targetTagData)
                return;

            health.Damage(damageAmount);

            if (disappearsOnCollision)
                gameObject.SetActive(false);
        }
    }
}
