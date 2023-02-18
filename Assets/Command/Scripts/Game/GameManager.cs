using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class GameManager : MonoBehaviour
    {
        public Mover mover;
        private Vector3 startPosition;
        private Vector2Int maxPos = new Vector2Int(9, 9);

        private Command buttonW;
        private Command buttonS;
        private Command buttonA;
        private Command buttonD;
        public Stack<Command> undoCommands = new Stack<Command>();
        public Stack<Command> redoCommands = new Stack<Command>();

        public static bool isReplaying;
        public static bool canInputGet;

        public CommandsDisplayer displayer;


        private void Awake()
        {
            canInputGet = true;
            startPosition = mover.transform.position;
            buttonW = new MoveUpCommand(mover);
            buttonA = new MoveLeftCommand(mover);
            buttonS = new MoveDownCommand(mover);
            buttonD = new MoveRightCommand(mover);
        }
        private void Update()
        {
            if(!canInputGet || isReplaying) return;
            if(Input.GetKeyDown(KeyCode.W) && mover.CurrentPos.y < maxPos.y) ExecuteNewCommand(buttonW);
            else if(Input.GetKeyDown(KeyCode.A)&& mover.CurrentPos.x > 0) ExecuteNewCommand(buttonA);
            else if(Input.GetKeyDown(KeyCode.S)&& mover.CurrentPos.y > 0) ExecuteNewCommand(buttonS);
            else if(Input.GetKeyDown(KeyCode.D)&& mover.CurrentPos.x < maxPos.y) ExecuteNewCommand(buttonD);
            else if(Input.GetKeyDown(KeyCode.U)) UndoCommand();
            else if(Input.GetKeyDown(KeyCode.Y)) RedoCommand();
        }


        public void Replay()
        {
            mover.transform.position = startPosition;
            Command[] oldCommands = undoCommands.Reverse().ToArray();
            isReplaying = true;
            Queue<Command> queuedCommands = new Queue<Command>();
            oldCommands.ToList().ForEach(x => queuedCommands.Enqueue(x));
            mover.StartCoroutine(mover.Replay(queuedCommands));
        }
        private void RedoCommand()
        {
            if (redoCommands.Count == 0)
                {
                    Debug.Log("Can't redo because we are at the end");
                }
                else
                {
                    Command nextCommand = redoCommands.Pop();

                    nextCommand.Exec();

                    undoCommands.Push(nextCommand);

                    displayer.AddCommand(nextCommand);
                }
        }
        private void UndoCommand()
        {
            if(undoCommands.Count == 0)
                return;
            Command lastCommand = undoCommands.Pop();
            lastCommand.Undo();
            redoCommands.Push(lastCommand);
            displayer.RemoveLastCommand();
        }

        private void ExecuteNewCommand(Command commandButton)
        {
            commandButton.Exec();

            undoCommands.Push(commandButton);

            displayer.AddCommand(commandButton);

            redoCommands.Clear();
        }
    }
}
