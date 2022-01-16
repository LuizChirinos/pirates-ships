using UnityEngine;
using Random = UnityEngine.Random;

namespace PiratesShip
{
    public class SpawnOnArea : Spawner
    {
        [SerializeField] protected float minRange = 2f;
        [SerializeField] protected float maxRange = 2f;

        public float RandomRange { get => Random.RandomRange(minRange, maxRange); }
        public int RandomSignal 
        {
            get
            {
                float random = Random.RandomRange(-1f, 1f);
                if (random > 0)
                    return 1;
                else
                    return -1;
            }
        }
        protected override GameObject CreateObject()
        {
            Vector3 randomOffset = new Vector3(RandomRange*RandomSignal, RandomRange*RandomSignal, 0f);
            return Instantiate(spawnData.ObjectToSpawn, pivot.position + randomOffset, pivot.rotation);
        }
    }
}
