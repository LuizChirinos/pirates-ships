using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    [SerializeField] private string horizontalInput = "Horizontal";
    [SerializeField] private string verticalInput = "Vertical";

    private float horizontal;
    private float vertical;

    public float Horizontal { get => horizontal; }
    public float Vertical { get => vertical; }

    private  void Update()
    {
        horizontal = Input.GetAxis(horizontalInput);
        vertical = Input.GetAxis(verticalInput);
    }
}
