using UnityEngine;
namespace CommandPattern
{
    public abstract class Command
    {
        public abstract void Exec(Transform _transform);
        public virtual void Undo(Transform _transform){}
        public virtual void Move(Transform _transform) { }
    }
    public class MoveLeft : Command
    {
        public override void Exec(Transform _transform)
        {

        }
        public override void Undo(Transform _transform)
        {

        }
        public override void Move(Transform _transform)
        {
            
        }
    }
}
