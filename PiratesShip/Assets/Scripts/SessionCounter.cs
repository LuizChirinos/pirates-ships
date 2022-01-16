using System;
using UnityEngine;

namespace PiratesShip.Session
{
    public class SessionCounter : MonoBehaviour
    {
        [SerializeField] private ScriptableNumber currentSessionTime;
        [SerializeField] private ScriptableNumber maxSessionTime;
        [SerializeField] private int updateNumberInterval = 1;
        [SerializeField] private bool savesSessionTime = false;

        private float counterInterval = 0;

        private void Start()
        {
            if (!savesSessionTime)
                currentSessionTime.SavedValue = maxSessionTime.SavedValue;
        }

        private void Update()
        {
            counterInterval += Time.deltaTime;

            if (counterInterval >= updateNumberInterval)
            {
                counterInterval = 0;
                currentSessionTime.SavedValue -= updateNumberInterval;
            }
        }
    }
}
