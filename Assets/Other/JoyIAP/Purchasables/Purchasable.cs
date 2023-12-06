using System;

namespace JoyIAP
{
    [Serializable]
    public class Purchasable : IDisposable
    {
        private IAPManager IAPManager;
        public PurchasableData Data;
        public event Action OnPurchaseSuccess;

        private bool _initialized = false;
        public void Initialize(IAPManager iapManager)
        {
            OnPurchaseSuccess = null;
            if (_initialized)
            {
                return;
            }
            _initialized = true;
            IAPManager = iapManager;
        }
        public void Purchase()
        {
            if(!_initialized)
            {
                throw new Exception("Purchasable is not initialized");
            }
            IAPManager.Purchase(this);
        }

        public void Dispose()
        {
            OnPurchaseSuccess = null;
            IAPManager = null;
            _initialized = false;
        }
    }
}