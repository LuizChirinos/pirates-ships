using PiratesShip.Tags;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PiratesShip.Targets
{
    [CreateAssetMenu(fileName = nameof(TargetsData), menuName = "Targets/TargetsData")]
    public class TargetsData : ScriptableObject
    {
        private List<Target> targets;

        public Transform GetClosestFrom(Vector3 point)
        {
            if (targets.Count == 0)
                return null;

            Transform target = targets.OrderBy(x => Vector3.Distance(point, x.transform.position)).ToList()[0].transform;

            return target;
        }
        public void AddTarget(Target target)
        {
            targets.Add(target);
        }
        public void RemoveTarget(Target target)
        {
            targets.Remove(target);
        }
        public void Clear()
        {
            targets.Clear();
        }
    }
}
