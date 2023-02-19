namespace CommandPattern
{
    public class MoveLeftCommand : Command
    {
        private Mover mover;
        public MoveLeftCommand(Mover mover)
        {
            this.mover = mover;
        }
        public override void Exec()
        {
            mover.MoveLeft();
        }

        public override void Undo()
        {
            mover.MoveRight();
        }
    }
}
