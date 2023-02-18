using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CommandPattern
{
    public class CommandsDisplayer : MonoBehaviour
    {
        public TextMeshProUGUI displayerText;
        private string text;
        //←↑→↓
        private const char left ='←';
        
        private const char right ='→';
        private const char up ='↑';
        private const char down ='↓';


    }
}
