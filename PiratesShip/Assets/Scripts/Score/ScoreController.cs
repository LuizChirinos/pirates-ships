using UnityEngine;

namespace PiratesShip.Score
{
    [CreateAssetMenu(fileName = nameof(ScoreController), menuName = "Score/ScoreController")]
    public class ScoreController : ScriptableObject
    {
        public delegate void OnScoreEvent(int amount);

        public event OnScoreEvent OnUpdatedScore;

        [SerializeField] private int initialScore = 0;

        public int SavedScore 
        {
            get => PlayerPrefs.GetInt(saveKey, initialScore);
            set
            {
                PlayerPrefs.SetInt(saveKey, value);
                OnUpdatedScore?.Invoke(value);
            }
        }
        private string saveKey => name;

        public void ResetScore() => PlayerPrefs.DeleteKey(saveKey);
        public void Add(int amount) => SavedScore += amount;
        public void Remove(int amount) => SavedScore -= amount;

    }
}
