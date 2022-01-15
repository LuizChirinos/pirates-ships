using UnityEngine;

namespace PiratesShip.Inputs
{
    public abstract class BaseInput : MonoBehaviour
    {
        protected float horizontal;
        protected float vertical;

        public float Horizontal { get => horizontal; }
        public float Vertical { get => vertical; }
        public Vector2 Direction { get => new Vector2(Horizontal, Vertical).normalized; }
    }
}
