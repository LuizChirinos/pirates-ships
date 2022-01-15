using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip.Tags
{
    public class EntityTag : MonoBehaviour
    {
        [SerializeField] private TagData tagData;

        public TagData TagData { get => tagData; }
    }
}
