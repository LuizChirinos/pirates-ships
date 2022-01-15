using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip.Targets
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private TargetsData targetsData;
        private void Awake()
        {
            targetsData.AddTarget(this);
        }
        private void OnDestroy()
        {
            targetsData.RemoveTarget(this);
        }
    }
}
