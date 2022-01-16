using PiratesShip.Damages;
using System;

namespace PiratesShip.Targets
{
    public class HealthTargetDetector : TargetDetector
    {
        protected override void Start()
        {
            base.Start();

            Health.OnAnyDeath += Remove;
        }
        protected virtual void OnDestroy()
        {
            Health.OnAnyDeath -= Remove;
        }
        private void Remove(Health health)
        {
            RemoveTarget(health.transform);
        }
    }
}
