using PiratesShip.Damages;
using UnityEngine;

namespace PiratesShip.Score
{
    [RequireComponent(typeof(Health))]
    public class ScoreRewardOnDeath : MonoBehaviour
    {
        [SerializeField] private ScriptableNumber scoreController;
        [SerializeField] private int amount = 1;
        private Health health;

        private void Start()
        {
            health = GetComponent<Health>();
            health.OnDeath += AddScore;
        }
        private void OnDestroy()
        {
            if (health)
                health.OnDeath -= AddScore;
        }

        public void AddScore() => scoreController.Add(amount);
    }
}
