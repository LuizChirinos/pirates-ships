using System;
using UnityEngine;

namespace PiratesShip.Life
{
    [RequireComponent(typeof(Health))]
    public class DeactivateOnDeath : MonoBehaviour
    {
        private Health health;

        private void Start()
        {
            health.OnDeath += Deactive;
        }
        private void OnDestroy()
        {
            health.OnDeath -= Deactive;
        }
        private void Deactive()
        {
            gameObject.SetActive(false);
        }
    }
}
