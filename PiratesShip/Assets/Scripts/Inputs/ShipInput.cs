using UnityEngine;

namespace PiratesShip.Inputs
{
    public class ShipInput : BaseInput
    {
        [SerializeField] private string horizontalInput = "Horizontal";
        [SerializeField] private string verticalInput = "Vertical";

        private void Update()
        {
            horizontal = Input.GetAxis(horizontalInput);
            vertical = Input.GetAxis(verticalInput);
        }
    }

}