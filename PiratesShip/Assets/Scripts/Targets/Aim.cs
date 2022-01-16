using PiratesShip.Movements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip.Targets
{
    [RequireComponent(typeof(TargetDetector))]
    public class Aim : MonoBehaviour
    {
        #region Events
        public delegate void OnTargetEvent();

        public OnTargetEvent OnTargetDetected;
        public OnTargetEvent OnTargetRemoved;
        #endregion

        #region Fields
        [SerializeField] private MovementData movementData;
        [SerializeField] private Transform pivot;
        [SerializeField] private Color debugColor = new Color(1f, 1f, 0f, 0.2f);
        protected TargetDetector targetDetector;
        protected Transform target;
        #endregion

        public bool HasTarget { get => target != null; }

        private void Start()
        {
            targetDetector = GetComponent<TargetDetector>();
            targetDetector.OnAdded += UpdateTarget;
            targetDetector.OnRemoved += TryRemoveTarget;
        }
        private void Update()
        {
            if (target == null)
                return;
            Vector3 dir = target.position - pivot.position;
            pivot.right = Vector3.Lerp(pivot.right, dir, Time.deltaTime * movementData.RotationSpeed);
        }
        private void OnDestroy()
        {
            targetDetector.OnAdded -= UpdateTarget;
            targetDetector.OnRemoved -= TryRemoveTarget;
        }
        private void OnDrawGizmos()
        {
            Color color = Gizmos.color;

            Gizmos.color = debugColor;
            Gizmos.DrawSphere(transform.position, transform.localScale.x/2f);
            Gizmos.color = color;
        }

        private void TryRemoveTarget(Transform target)
        {
            if (this.target == target)
            {
                this.target = null;
                OnTargetRemoved?.Invoke();
            }
        }
        private void UpdateTarget(Transform target)
        {
            if (this.target == null)
            {
                this.target = target;

                Vector3 dir = target.position - pivot.position;
                pivot.right = dir;
                OnTargetDetected?.Invoke();
            }
        }
    }
}
