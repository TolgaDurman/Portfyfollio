namespace JoyIAP
{
    public class Consumable : Purchasable
    {
        private bool _isConsumed;
        public bool IsConsumed()
        {
            return _isConsumed;
        }
        public void Consume()
        {
            _isConsumed = true;
        }
    }
}