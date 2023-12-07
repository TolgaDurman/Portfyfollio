using UnityEngine;

namespace DW_IAP
{
    [CreateAssetMenu(fileName = "PurchasableObjectsList", menuName = "JoyIAP/Purchasable Objects List")]
    public class PurchasableObjectsList : ScriptableObject
    {
        public PurchasableObject[] PurchasableObjects;
    }
}
