using UnityEngine.Events;

namespace DW_IAP
{
    public sealed class Consumable : Purchasable
    {
        private bool _isConsumed;

        public Consumable(PurchasableData data, IAPManager iapManager, UnityAction onPurchaseSuccess = null) : base(data, iapManager, onPurchaseSuccess)
        {

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