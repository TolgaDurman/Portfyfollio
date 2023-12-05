namespace JoyIAP
{
    public class Consumable : Purchasable
    {
        private bool _isConsumed;
        public Consumable(PurchasableData data) : base(data) { }
        public Consumable(PurchasableData data, bool isConsumed) : base(data)
        {
            _isConsumed = isConsumed;
        }
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