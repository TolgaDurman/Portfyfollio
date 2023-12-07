using System;
using UnityEngine.Purchasing;

namespace DW_IAP
{
    public sealed class CloudProvider : IDisposable
    {
            private IStoreController _storeController;
            public CloudProvider(IStoreController storeController)
            {
                _storeController = storeController;
            }


        public void SavePurchase(PurchaseEventArgs args)
            {
                // Save purchase to cloud

                // If successful, call OnPurchaseSaved
                OnPurchaseSaved(args);
            }

            private void OnPurchaseSaved(PurchaseEventArgs args)
            {
                // Purchase saved to cloud
                _storeController.ConfirmPendingPurchase(args.purchasedProduct);
            }
        public void Dispose()
        {
            _storeController = null;
        }
    }
}