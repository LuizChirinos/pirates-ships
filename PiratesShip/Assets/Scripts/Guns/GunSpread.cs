using UnityEngine;

namespace PiratesShip.Guns
{
    public class GunSpread : Gun
    {
        [SerializeField] private int numberOfShoots = 3;
        [SerializeField] private float angleBetween = 15;

        protected override void CreateShoot(Vector2 pos, Quaternion rot, Transform parent)
        {
            for (int i = 0; i < numberOfShoots; i++)
            {
                float currentAngle = i * angleBetween - (numberOfShoots* angleBetween) / 2f;
                Quaternion currentRotation = rot * Quaternion.Euler(Vector3.forward * currentAngle);

                Instantiate(shootPrefab, pos, currentRotation, parent);
            }
        }
    }
}
