using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace JoyIAP
{
    public class IAPManager : IDetailedStoreListener
    {
        private IStoreController _controller;
        private Queue<Purchasable> _purchasables = new Queue<Purchasable>();
        public IAPManager(List<Purchasable> purchasables)
        {
            purchasables.ForEach(purchasable =>
            {
                if (!purchasable.Data.Tag.Equals(null))
                {
                    _purchasables.Enqueue(purchasable);
                }
            });

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            while (_purchasables.Count > 0)
            {
                var purchasable = _purchasables.Dequeue();
                builder.AddProduct(purchasable.Data.Id, purchasable.Data.Type);
            }

            UnityPurchasing.Initialize(this, builder);
        }
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _controller = controller;
            Debug.Log("IAPManager Initialized");
        }
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            throw new System.NotImplementedException();
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            throw new System.NotImplementedException();
        }
        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            throw new System.NotImplementedException();
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            throw new System.NotImplementedException();
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            throw new System.NotImplementedException();
        }
    }
}
