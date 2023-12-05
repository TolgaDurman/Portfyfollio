using System;

namespace JoyIAP
{
    [Serializable]
    public class Purchasable
    {
        public event Action OnPurchaseSuccess;
        public PurchasableData Data { get; private set; }
        public Purchasable(PurchasableData data)
        {
            Data = data;
        }
    }
}