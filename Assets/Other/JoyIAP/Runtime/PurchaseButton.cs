using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace JoyIAP
{
    [RequireComponent(typeof(Button))]
    public sealed class PurchaseButton : MonoBehaviour
    {
        public UnityEvent OnPurchaseSuccessEvent;
        [SerializeField] private PurchasableObject _purchasableObject;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        private void Start()
        {
            _purchasableObject.Purchasable.OnPurchaseSuccess += OnPurchaseSuccessEvent.Invoke;
            _priceText.text = _purchasableObject.Purchasable.Data.Price.ToString();
            if(_descriptionText != null) _descriptionText.text = _purchasableObject.Purchasable.Data.Description;
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _purchasableObject.Purchasable.Purchase();
        }
    }
}
