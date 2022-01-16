using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip
{
    public class Lifetime : MonoBehaviour
    {
        [SerializeField] private float deactivationLifeTime = 1f;
        private void Start()
        {
            Invoke(nameof(Deactivate), deactivationLifeTime);
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
