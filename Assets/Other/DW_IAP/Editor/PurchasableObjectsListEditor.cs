using DW_IAP;
using UnityEditor;
using UnityEngine;

namespace JoyIAPEditor
{
    [CustomEditor(typeof(PurchasableObjectsContainer))]
    public sealed class PurchasableObjectsContainerEditor : Editor
    {
        private PurchasableObjectsContainer _purchasableObjectsList;

        private void OnEnable()
        {
            _purchasableObjectsList = (PurchasableObjectsContainer) target;
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
