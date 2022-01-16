using PiratesShip.Life;
using PiratesShip.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip
{
    public class EnemyBridgeEvents : MonoBehaviour
    {
        private Health health;
        private EntityMovement entityMovement;
        private void Awake()
        {
            health = GetComponent<Health>();
            entityMovement = GetComponent<EntityMovement>();
            health.OnDeath += entityMovement.LockMovement;
        }
        private void OnDestroy()
        {
            health.OnDeath -= entityMovement.LockMovement;
        }
    }
}
