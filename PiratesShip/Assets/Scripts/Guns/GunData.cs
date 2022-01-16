using System.Collections;
using UnityEngine;

namespace PiratesShip.Guns
{
    [CreateAssetMenu(fileName = nameof(GunData), menuName = "Guns/GunData")]
    public class GunData : ScriptableObject
    {
        [SerializeField] private bool hasCooldown = false;
        [SerializeField] private float cooldownTime = 0.5f;

        [SerializeField] private int maxAmmo;
        [SerializeField] private bool spentAmmo = false;

        public int MaxAmmo { get => maxAmmo; }
        public float CooldownTime { get => cooldownTime; }
        public bool HasCooldown { get => hasCooldown; }

        public void SetAmmo(ref int currentAmmo)
        {
            currentAmmo = maxAmmo;
        }
        public void SpentAmmo(ref int currentAmmo)
        {
            if (!spentAmmo)
                return;

            currentAmmo--;
            currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
        }
    }
}
