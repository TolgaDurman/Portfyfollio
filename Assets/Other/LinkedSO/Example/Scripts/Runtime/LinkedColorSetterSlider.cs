using UnityEngine;
using UnityEngine.UI;

namespace LinkedSO.Demo
{
    public class LinkedColorSetterSlider : MonoBehaviour
    {
        public Image handleImage;
        public LinkableColor color;
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
