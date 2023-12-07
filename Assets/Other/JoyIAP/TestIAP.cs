using DW_IAP;
using Unity.VisualScripting;
using UnityEngine;

public class TestIAP : MonoBehaviour
{
    public IAPManager IAPManager;
    void Start()
    {
        IAPManager = new IAPManager();
    }
    void OnApplicationQuit()
    {
        IAPManager.Dispose();
    }
}
