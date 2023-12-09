using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DW_IAP
{
    [RequireComponent(typeof(Button))]
    public sealed class PurchaseButton : MonoBehaviour
    {
        [SerializeField] private PurchasableObject _purchasableObject;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        private void Start()
        {
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
