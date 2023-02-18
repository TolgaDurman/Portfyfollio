namespace CommandPattern
{
    public class MoveDownCommand : Command
    {
        private Mover mover;
        public MoveDownCommand(Mover mover)
        {
            this.mover = mover;
        }

        public override void Exec()
        {
            mover.MoveDown();
        }

        public override void Undo()
        {
            mover.MoveUp();
        }
    }
}
