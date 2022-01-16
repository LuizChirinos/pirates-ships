using UnityEngine;

namespace PiratesShip
{
    [CreateAssetMenu(fileName = nameof(ScriptableNumber), menuName = "Score/ScoreController")]
    public class ScriptableNumber : ScriptableObject
    {
        public delegate void OnUpdateEvent(int amount);

        public event OnUpdateEvent OnUpdated;

        [SerializeField] private int initialValue = 0;

        public int SavedValue 
        {
            get => PlayerPrefs.GetInt(saveKey, initialValue);
            set
            {
                PlayerPrefs.SetInt(saveKey, value);
                OnUpdated?.Invoke(value);
            }
        }
        private string saveKey => name;

        public void Reset() => PlayerPrefs.DeleteKey(saveKey);
        public void Add(int amount) => SavedValue += amount;
        public void Remove(int amount) => SavedValue -= amount;

    }
}
