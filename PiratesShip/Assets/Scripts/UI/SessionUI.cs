using System;
using UnityEngine;
using UnityEngine.UI;

namespace PiratesShip.Session
{
    public class SessionUI : MonoBehaviour
    {
        [SerializeField] private ScriptableNumber currentSessionTime;
        [SerializeField] private Text currentSessionText;

        private void Start()
        {
            currentSessionTime.OnUpdated += UpdateText;
        }
        private void OnDestroy()
        {
            currentSessionTime.OnUpdated -= UpdateText;
        }

        private void UpdateText(int amount)
        {
            currentSessionText.text = $"Session = {currentSessionTime.SavedValue}";
        }
    }
}
