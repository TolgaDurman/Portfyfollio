using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Purchasing;

namespace DW_IAP
{
    [CreateAssetMenu(fileName = "PurchasableObjectsContainer", menuName = "JoyIAP/Purchasable Objects Container")]
    public class PurchasableObjectsContainer : ScriptableObject
    {
        [Expandable] public PurchasableObject[] PurchasableObjects;

        public void SetupMetadataOf(IAPManager manager, string productName, ProductMetadata metadata)
        {
            foreach (var purchasableObject in PurchasableObjects)
            {
                if (purchasableObject.name == productName)
                {
                    purchasableObject.Init(manager, new PurchasableData(metadata.localizedTitle, metadata.localizedDescription, metadata.localizedPriceString), null);
                    return;
                }
            }
        }
    }
}
