using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinkedSO
{
    public abstract class LinkableItemUser<T> : MonoBehaviour where T : LinkableSOItem
    {
        public T myObject;
    }
}
