using PiratesShip.Damages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip
{
    [RequireComponent(typeof(Spawner))]
    public class UpdateDeadSpawns : MonoBehaviour
    {
        private Spawner spawner;

        #region Monobehaviour callbacks
        private void Start()
        {
            spawner = GetComponent<Spawner>();
            Health.OnAnyDeath += Remove;
        }
        private void OnDestroy()
        {
            Health.OnAnyDeath -= Remove;
        }
        #endregion

        private void Remove(Health health)
        {
            spawner.DeacreaseSpawned(health.gameObject);
        }
    }
}
