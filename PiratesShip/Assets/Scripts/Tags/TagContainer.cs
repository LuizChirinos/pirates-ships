using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PiratesShip.Tags
{
    public class TagContainer : MonoBehaviour
    {
        [SerializeField] private TagData tagData;

        public TagData TagData { get => tagData; }
    }
}
