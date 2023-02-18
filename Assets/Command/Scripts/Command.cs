namespace CommandPattern
{
    public abstract class Command
    {
        public abstract void Exec();
        public abstract void Undo();
    }
}
