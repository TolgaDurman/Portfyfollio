using System;
using System.Collections.Generic;
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
        private List<NonConsumable> _nonConsumables = new List<NonConsumable>();
        private List<Consumable> _consumables = new List<Consumable>();
        private List<Subscription> _subscriptions = new List<Subscription>();
        public IAPManager()
        {
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            _purchasables = Resources.Load<PurchasableObjectsList>("PurchasableObjectsList");
            Debug.Log("Purchasables found :" + _purchasables.name);
            SetupPurchasables();
            Initialize(builder);
        }
        private void SetupPurchasables()
        {
            foreach (var item in _purchasables.PurchasableObjects)
            {
                switch (item.Data.Type)
                {
                    case ProductType.NonConsumable:
                        NonConsumable nonConsumable = new NonConsumable(item.Data, this, item.OnPurchased);
                        item.Init(nonConsumable);
                        _nonConsumables.Add(nonConsumable);
                        break;
                    case ProductType.Consumable:
                        Consumable consumable = new Consumable(item.Data, this, item.OnPurchased);
                        item.Init(consumable);
                        _consumables.Add(consumable);
                        break;
                    case ProductType.Subscription:
                        Subscription subscription = new Subscription(item.Data, this, item.OnPurchased);
                        item.Init(subscription);
                        _subscriptions.Add(subscription);
                        break;
                }
            }
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
                item.Dispose();
            }
        }
    }
}
