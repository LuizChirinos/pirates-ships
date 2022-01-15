using UnityEngine;

namespace PiratesShip.Life
{
    public class Health : MonoBehaviour
    {
        #region Events
        public delegate void OnLifeEvent();
        public delegate void OnLifeChanged(float lifeValue);

        public OnLifeEvent OnDeath;
        public OnLifeEvent OnHit;

        public OnLifeChanged OnLifeSet;
        public OnLifeChanged OnDamageTaken;
        #endregion

        #region Fields
        [SerializeField] private float maxLife = 3;
        [SerializeField] private float currentLife = 0;
        [SerializeField] private bool isInvincible = false;
        #endregion

        #region Properties
        public float MaxLife { get => maxLife; }
        public float CurrentLife { get => currentLife; }
        public bool IsDead { get => currentLife <= 0; }
        public bool IsInvincible { get => IsInvincible; }
        #endregion

        private void OnEnable()
        {
            currentLife = maxLife;
            OnLifeSet?.Invoke(currentLife);
        }

        public bool Damage(float damageAmount)
        {
            if (IsDead)
                return false;
            if(IsInvincible)
                return false;
            if (damageAmount <= 0)
                return false;

            float damageTaken = Mathf.Clamp(damageAmount, 0f, currentLife);

            currentLife -= damageAmount;
            currentLife = Mathf.Clamp(currentLife, 0f, MaxLife);

            OnLifeSet?.Invoke(currentLife);
            OnDamageTaken?.Invoke(damageTaken);

            if (IsDead)
                OnDeath?.Invoke();

            return true;
        }
    }
}
