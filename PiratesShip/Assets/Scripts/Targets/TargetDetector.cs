using PiratesShip.Tags;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip.Targets
{
    public class TargetDetector : MonoBehaviour
    {
        public delegate void OnTargetEvent(Transform target);
        public OnTargetEvent OnAdded;
        public OnTargetEvent OnRemoved;

        [SerializeField] protected TagData tagData;
        protected List<Transform> possibleTargets;

        protected virtual void Start()
        {
            possibleTargets = new List<Transform>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out TagContainer tagContainer))
                return;

            AddTarget(tagContainer.transform);
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent(out TagContainer tagContainer))
                return;

            RemoveTarget(tagContainer.transform);
        }

        public void AddTarget(Transform target)
        {
            possibleTargets.Add(target);
            OnAdded?.Invoke(target);
        }
        public void RemoveTarget(Transform target)
        {
            possibleTargets.Remove(target);
            OnRemoved?.Invoke(target);
        }
    }
}
