using UnityEngine;

namespace PiratesShip.Guns
{
    [System.Serializable]
    public class EntityGuns
    {
        [SerializeField] private Gun gun;
        [SerializeField] KeyCode gunKey;

        public Gun Gun { get => gun; }
        public KeyCode GunKey { get => gunKey; set => gunKey = value; }
    }
}
