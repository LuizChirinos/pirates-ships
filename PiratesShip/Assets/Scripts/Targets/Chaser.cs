using PiratesShip.Inputs;
using PiratesShip.Targets;
using UnityEngine;

namespace PiratesShip
{
    public class Chaser : BaseInput
    {
        [SerializeField] private TargetsData targets;

        private Transform targetObject;

        private void Start()
        {
            targetObject = targets.GetClosestFrom(transform.position);
        }

        private void Update()
        {
            if (targetObject == null)
                return;

            Vector3 dir = targetObject.position - transform.position;
            dir.Normalize();
            horizontal = dir.x;
            vertical = dir.y;
        }
    }
}
