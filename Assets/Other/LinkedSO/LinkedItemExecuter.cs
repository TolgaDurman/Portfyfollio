using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinkedSO
{
    public class LinkedItemExecuter : MonoBehaviour
    {
        [SerializeField]private LinkableSOItem item;
        public void Execute()
        {
            if(item != null)
                item.Execute();
        }
    }
}
