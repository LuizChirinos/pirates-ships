using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip
{
    [CreateAssetMenu(fileName = nameof(SpawnData), menuName = "Spawn/SpawnData")]
    public class SpawnData : ScriptableObject
    {
        [SerializeField] private GameObject objectToSpawn;
        [SerializeField] private float spawnCooldown = 3f;
        [SerializeField] private int maxSpawnedObjects = 3;
        [SerializeField] private bool hasSpawnLimit;

        public float SpawnCooldown { get => spawnCooldown; }
        public GameObject ObjectToSpawn { get => objectToSpawn; }
        public int MaxSpawnedObjects { get => maxSpawnedObjects; }
        public bool HasSpawnLimit { get => hasSpawnLimit; }

        public bool ReachedMaxNumberOfSpawned(int numberOfSpawned)
        {
            return numberOfSpawned >= maxSpawnedObjects;
        }
    }
}
