namespace CommandPattern
{
    public class MoveUpCommand : Command
    {
        private Mover mover;
        public MoveUpCommand(Mover mover)
        {
            this.mover = mover;
        }
        public override void Exec()
        {
            mover.MoveUp();
        }

        public override void Undo()
        {
            mover.MoveDown();
        }
    }
}
