using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exposable
{
    public class ExposedItemExecuter : MonoBehaviour
    {
        [SerializeField]private ExposedItem item;
        public void Execute()
        {
            item.Execute();
        }
    }
}
