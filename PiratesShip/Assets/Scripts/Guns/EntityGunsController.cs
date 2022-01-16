using UnityEngine;

namespace PiratesShip.Guns
{
    public class EntityGunsController : MonoBehaviour
    {
        [SerializeField] private EntityGuns[] entityGuns;

        private void Update()
        {
            foreach (var item in entityGuns)
            {
                if (Input.GetKeyDown(item.GunKey))
                {
                    item.Gun.Shoot();
                }
            }
        }
    }
}
