using UnityEngine;

[CreateAssetMenu(fileName = nameof(MovementData), menuName = "Movement/MovementData")]
public class MovementData : ScriptableObject
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotationSpeed = 10f;

    public float Speed { get => speed; }
    public float RotationSpeed { get => rotationSpeed;}
}
