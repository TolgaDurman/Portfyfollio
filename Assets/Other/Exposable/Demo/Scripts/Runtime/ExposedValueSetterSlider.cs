using UnityEngine;
using UnityEngine.UI;

namespace Exposable.Demo
{
    public class ExposedValueSetterSlider : MonoBehaviour
    {
        public Image handleImage;
        public ExposedColor color;
        public GradientToTexture gradient;
        public bool updateOnChange = false;
        public void SliderValue(float value)
        {
            Color getted = gradient.GetColor(value);
            color.shared = getted;
            handleImage.color = getted;
            if(updateOnChange)
                color.Execute();
        }
    }
}
