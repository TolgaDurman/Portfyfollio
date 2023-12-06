using System;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace JoyIAP
{
    public class IAPManager : IDetailedStoreListener, IDisposable
    {
        private IStoreController _controller;
        private PurchasableObjectsList _purchasables;
        public IAPManager()
        {
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            _purchasables = Resources.Load<PurchasableObjectsList>("PurchasableObjectsList");
            Debug.Log("Purchasables found :" + _purchasables.name);
            foreach (var purchasableObject in _purchasables.PurchasableObjects)
            {
                purchasableObject.Purchasable.Initialize(this);
                Purchasable purchasable = purchasableObject.Purchasable;
                builder.AddProduct(purchasable.Data.Id, purchasable.Data.Type);
            }
            Initialize(builder);
        }
        private async void Initialize(ConfigurationBuilder builder)
        {
            try
            {
                await UnityServices.InitializeAsync();
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                UnityPurchasing.Initialize(this, builder);
            }
        }
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _controller = controller;
            Debug.Log("IAPManager Initialized");
        }
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.LogWarning("IAPManager Cannot Initialize reason:" + error);
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            Debug.LogWarning("IAPManager Cannot Initialize reason:" + error + "\n Message:" + message);
        }
        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            Debug.Log("IAPManager Purchase Success product:" + purchaseEvent.purchasedProduct.receipt);
            return PurchaseProcessingResult.Complete;
        }
        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.LogWarning("IAPManager Purchase Failed product:" + product + "\n failureReason:" + failureReason);
        }
        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            Debug.LogWarning("IAPManager Purchase Failed product:" + product + "\n failureDescription:" + failureDescription);
        }

        internal void Purchase(Purchasable purchasable)
        {
            _controller.InitiatePurchase(purchasable.Data.Id);
        }

        public void Dispose()
        {
            foreach (var item in _purchasables.PurchasableObjects)
            {
                item.Purchasable.Dispose();
            }
        }
    }
}
