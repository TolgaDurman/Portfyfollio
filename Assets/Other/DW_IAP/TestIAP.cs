using DW_IAP;
using UnityEngine;

public class TestIAP : MonoBehaviour
{
    public IAPManager IAPManager;
    void Awake()
    {
        IAPManager = new IAPManager();
    }
    void OnApplicationQuit()
    {
        IAPManager.Dispose();
    }
}
