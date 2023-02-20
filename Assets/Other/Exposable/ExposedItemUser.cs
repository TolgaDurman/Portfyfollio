using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exposable
{
    public abstract class ExposedItemUser<T> : MonoBehaviour where T : ExposedItem
    {
        public T myObject;
    }
}
