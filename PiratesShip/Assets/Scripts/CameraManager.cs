using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip
{
    public class CameraManager : MonoBehaviour
    {
        private static CameraManager instance;

        private Camera mainCamera;

        public static CameraManager Instance { get => instance; }
        public static Camera MainCamera
        {
            get
            {
                if (instance.mainCamera == null)
                    instance.mainCamera = instance.GetComponent<Camera>();

                return instance.mainCamera;
            }
        }


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
                Destroy(gameObject);
        }
    }
}
