using PiratesShip.Damages;
using PiratesShip.Guns;
using PiratesShip.Targets;
using System;
using UnityEngine;

namespace PiratesShip
{
    public class EnemyShooter : MonoBehaviour
    {
        private Gun[] guns;
        private Aim aim;
        private Health health;
        private void Start()
        {
            health = GetComponent<Health>();
            aim = GetComponentInChildren<Aim>();
            guns = GetComponentsInChildren<Gun>();

            health.OnDeath += DeactivateGuns;
        }
        private void OnDestroy()
        {
            health.OnDeath -= DeactivateGuns;
        }

        private void DeactivateGuns()
        {
            foreach (var item in guns)
            {
                item.gameObject.SetActive(false);
            }
            aim.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!aim.HasTarget)
                return;

            foreach (var item in guns)
            {
                item.Shoot();
            }
        }
    }
}
