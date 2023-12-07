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
            _purchasableObject.OnPurchased += OnPurchaseSuccessEvent.Invoke;
            _priceText.text = _purchasableObject.Data.Price.ToString();
            if(_descriptionText != null) _descriptionText.text = _purchasableObject.Data.Description;
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _purchasableObject.Purchase();
        }
    }
}
