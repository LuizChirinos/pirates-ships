using UnityEngine;

namespace PiratesShip.Guns
{
    public class Gun : MonoBehaviour
    {
        #region Events
        public delegate void OnShootEvent();

        public OnShootEvent OnShoot;
        #endregion

        #region Fields
        [SerializeField] protected GameObject shootPrefab;
        [SerializeField] protected GunData gunData;
        protected int currentAmmo = 0;
        protected float lastShotTime = 0;
        #endregion

        #region Properties
        public virtual bool CanShoot
        {
            get
            {
                return Time.time > lastShotTime + gunData.CooldownTime;
            }
        }
        #endregion

        protected virtual void Start()
        {
            gunData.SetAmmo(ref currentAmmo);
        }

        #region Shoot methods
        public virtual bool Shoot()
        {
            if (!CanShoot)
                return false;

            gunData.SpentAmmo(ref currentAmmo);

            lastShotTime = Time.time;
            CreateShoot(transform.position, transform.rotation, null);

            return true;
        }
        protected virtual void CreateShoot(Vector2 pos, Quaternion rot, Transform parent)
        {
            Instantiate(shootPrefab, pos, rot, parent);
        }
        #endregion
    }
}
