using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] protected SpawnData spawnData;
        [SerializeField] protected Transform pivot;

        protected int numSpawnedObjects = 0;

        private List<GameObject> spawnedObjects;

        public bool ReachedNumberOfSpawned { get => numSpawnedObjects >= spawnData.MaxSpawnedObjects; }

        private void Start()
        {
            spawnedObjects = new List<GameObject>();
            StartCoroutine(SpawnCoroutine());
        }

        #region Public methods
        public void Spawm()
        {
            GameObject spawned = CreateObject();
            IncreaseSpawned(spawned);
        }
        public void IncreaseSpawned(GameObject go)
        {
            numSpawnedObjects++;
            spawnedObjects.Add(go);
        }
        public void DeacreaseSpawned(GameObject go)
        {
            numSpawnedObjects--;
            spawnedObjects.Remove(go);
        }
        #endregion

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                if (spawnData.HasSpawnLimit && ReachedNumberOfSpawned)
                {
                    yield return null;
                    continue;
                }

                yield return new WaitForSeconds(spawnData.SpawnCooldown);

                Spawm();
            }
        }
        protected virtual GameObject CreateObject()
        {
            return Instantiate(spawnData.ObjectToSpawn, pivot.position, pivot.rotation);
        }
    }
}
