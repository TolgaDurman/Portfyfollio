using UnityEngine;

namespace JoyIAP
{
    [CreateAssetMenu(fileName = "PurchasableObject", menuName = "JoyIAP/Purchasable Object")]
    public class PurchasableObject : ScriptableObject
    {
        public Purchasable Purchasable;
    }
}
