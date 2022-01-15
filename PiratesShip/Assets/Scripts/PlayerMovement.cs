using UnityEngine;

[RequireComponent(typeof(ShipInput), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementData movementData;
    private ShipInput shipInput;
    private Rigidbody2D rb;

    private void Start()
    {
        shipInput = GetComponent<ShipInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement = new Vector2(shipInput.Horizontal, shipInput.Vertical).normalized;
        rb.velocity = movement * movementData.Speed;

        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.Euler(Vector3.forward * angle);
        if(movement.magnitude > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * movementData.RotationSpeed);
    }
}
