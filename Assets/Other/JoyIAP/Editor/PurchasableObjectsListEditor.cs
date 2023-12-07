using DW_IAP;
using UnityEditor;
using UnityEngine;

namespace JoyIAPEditor
{
    [CustomEditor(typeof(PurchasableObjectsList))]
    public sealed class PurchasableObjectsListEditor : Editor
    {
        private PurchasableObjectsList _purchasableObjectsList;

        private void OnEnable()
        {
            _purchasableObjectsList = (PurchasableObjectsList) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Reload"))
            {
                ReloadPurchasables();
            }
        }

        private void ReloadPurchasables()
        {
            _purchasableObjectsList.PurchasableObjects = Resources.LoadAll<PurchasableObject>("Purchasables");
            EditorUtility.SetDirty(_purchasableObjectsList);
        }
    }
}
