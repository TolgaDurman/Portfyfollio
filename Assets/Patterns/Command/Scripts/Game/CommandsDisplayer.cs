using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Voxelity.Extensions;

namespace CommandPattern
{
    public class CommandsDisplayer : MonoBehaviour
    {
        public TextMeshProUGUI displayerText;
        public Color highlightColor;
        private string text;
        //←↑→↓
        private const char left ='←';
        
        private const char right ='→';
        private const char up ='↑';
        private const char down ='↓';

        public void AddCommand(Command command)
        {
            if(command is MoveUpCommand)
            {
                text += up;
            }
            else if(command is MoveDownCommand)
            {
                text += down;
            }
            else if(command is MoveRightCommand)
            {
                text += right;
            }
            else if(command is MoveLeftCommand)
            {
                text += left;
            }
            displayerText.text = text;
        }
        public void ColorizeStep(int step)
        {
            string coloredText = text;
            string firstPart = coloredText.Substring(0, step);
            string secondPart = coloredText.Substring(step);
            string coloredDisplay = secondPart[0].ToString().Colorize(highlightColor);
            secondPart = secondPart.Remove(0,1);
            coloredText = firstPart + coloredDisplay + secondPart;
            displayerText.text = coloredText;
        }
        public void RemoveLastCommand()
        {
            text = text.Remove(text.Length - 1);
            displayerText.text = text;
        }
    }
}
