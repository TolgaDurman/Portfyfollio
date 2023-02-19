namespace CommandPattern
{
    public class MoveRightCommand : Command
    {
        private Mover mover;
        public MoveRightCommand(Mover mover)
        {
            this.mover = mover;
        }
        public override void Exec()
        {
            mover.MoveRight();
        }

        public override void Undo()
        {
            mover.MoveLeft();
        }
    }
}
