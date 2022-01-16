using System;
using UnityEngine;
using UnityEngine.UI;

namespace PiratesShip.Score
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private ScriptableNumber scoreController;

        private void Start()
        {
            scoreController.OnUpdated += UpdateScore;
            UpdateScore();
        }
        private void OnDestroy()
        {
            scoreController.OnUpdated -= UpdateScore;
        }

        private void UpdateScore()
        {
            scoreText.text = $"Score = {scoreController.SavedValue}";
        }
        private void UpdateScore(int amount)
        {
            scoreText.text = $"Score = {amount}";

        }
    }
}
