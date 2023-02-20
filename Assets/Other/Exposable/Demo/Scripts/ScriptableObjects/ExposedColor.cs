using System;
using UnityEngine;

namespace Exposable.Demo
{
    [CreateAssetMenu(menuName ="Demo/Exposable/Color",fileName ="New Exposed Color")]
    public class ExposedColor : ExposedItem
    {
        public Color shared;
        public event Action<Color> GiveColor;
        public override void Execute()
        {
            GiveColor?.Invoke(shared);
        }
    }
}