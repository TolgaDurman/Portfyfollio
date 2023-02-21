using System;
using UnityEngine;

namespace LinkedSO.Demo
{
    [CreateAssetMenu(menuName ="Demo/LinkedSO/Color",fileName ="New Linkable Color")]
    public class LinkableColor : LinkableSOItem
    {
        public Color shared;
        public event Action<Color> GiveColor;
        public override void Execute()
        {
            GiveColor?.Invoke(shared);
        }
    }
}