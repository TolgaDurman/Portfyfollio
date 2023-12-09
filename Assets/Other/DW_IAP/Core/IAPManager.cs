using System;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace DW_IAP
{
    public sealed class IAPManager : IDetailedStoreListener, IDisposable
    {
        private IStoreController _controller;
        private CloudProvider _cloudProvider;
        private PurchasableObjectsContainer _container;
        private bool _useCloud;

        public IAPManager(bool useCloud = false)
        {
            _useCloud = useCloud;
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            _container = Resources.FindObjectsOfTypeAll<PurchasableObjectsContainer>()[0];
            Debug.Log("Purchasables found :" + _container.name);
            SetupPurchasables(builder);
            Initialize(builder);
        }
        private void SetupPurchasables(ConfigurationBuilder builder)
        {
            foreach (var item in _container.PurchasableObjects)
            {

                builder.AddProduct(item.name, item.Type, new IDs() { { item.name, AppleAppStore.Name }, { item.name, GooglePlay.Name } });
            }
        }
        private async void Initialize(ConfigurationBuilder builder)
        {
            try
            {
                await UnityServices.InitializeAsync();
            }
            catch (Exception e)
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
            if (_useCloud)
                    _cloudProvider = new CloudProvider(_controller);
            foreach (var item in controller.products.all)
            {
                _container.SetupMetadataOf(this, item.definition.id, item.metadata);
            }
            Debug.Log("IAPManager Initialized Successfully / Cloud Enabled:" + _useCloud);
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
            Debug.Log(purchaseEvent.purchasedProduct.definition.id);

            return _useCloud ? PurchaseProcessingResult.Pending : PurchaseProcessingResult.Complete;
        }
        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.LogWarning("IAPManager Purchase Failed product:" + product + "\n failureReason:" + failureReason);
        }
        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            Debug.LogWarning("IAPManager Purchase Failed product:" + product + "\n failureDescription:" + failureDescription);
        }

        internal void Purchase(PurchasableObject purchasable)
        {
            _controller.InitiatePurchase(purchasable.name);
        }

        public void Dispose()
        {
            foreach (var item in _container.PurchasableObjects)
            {
                item.Dispose();
            }
            _container = null;
            _controller = null;
            _cloudProvider?.Dispose();
        }
    }
}
