using System.Collections;
using UnityEngine;

namespace PiratesShip.Damages
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
        [Space(10)]
        [SerializeField] private float dieLifetime = 1f;
        #endregion

        #region Properties
        public float MaxLife { get => maxLife; }
        public float CurrentLife { get => currentLife; }
        public bool IsDead { get => currentLife <= 0; }
        public bool IsInvincible { get => isInvincible; }
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
            if (IsInvincible)
                return false;
            if (damageAmount <= 0)
                return false;

            float damageTaken = Mathf.Clamp(damageAmount, 0f, currentLife);

            currentLife -= damageAmount;
            currentLife = Mathf.Clamp(currentLife, 0f, MaxLife);

            OnLifeSet?.Invoke(currentLife);
            OnDamageTaken?.Invoke(damageTaken);

            if (IsDead)
            {
                StartCoroutine(DieCoroutine());
                OnDeath?.Invoke();
            }

            return true;
        }

        private IEnumerator DieCoroutine()
        {
            float elapsedTime = 0;

            while (elapsedTime < dieLifetime)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}
