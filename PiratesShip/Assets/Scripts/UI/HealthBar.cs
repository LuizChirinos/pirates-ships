using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PiratesShip.Damages
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        private Health health;
        private Slider sliderBar;

        #region Monobehaviour callbacks
        private void Awake()
        {
            health = GetComponentInParent<Health>();
            sliderBar = GetComponentInChildren<Slider>();
        }
        private void OnEnable()
        {
            sliderBar.maxValue = health.MaxLife;
            health.OnLifeSet += UpdateBar;
            health.OnDeath += Deactivate;
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (health)
                health.OnLifeSet -= UpdateBar;
        }
        private void OnValidate()
        {
            if (transform.parent)
                transform.SetPositionAndRotation(transform.parent.position + offset, Quaternion.Euler(0f, 0f, 0f));
        }
        private void Update()
        {
            if (transform.parent == null)
                return;
            transform.SetPositionAndRotation(transform.parent.position + offset, Quaternion.Euler(0f, 0f, 0f));
        }
        #endregion

        private void UpdateBar(float lifeValue)
        {
            gameObject.SetActive(true);
            sliderBar.value = lifeValue;
        }
    }
}
