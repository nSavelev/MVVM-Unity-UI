using System;
using UnityEngine;

namespace UIManager.Runtime.Screen
{
    public abstract class BaseScreen : MonoBehaviour, IDisposable
    {
        public abstract Type ModelType { get; }

        public abstract void Show();
        public abstract void Close();
        public abstract void Bind(object model);

        public virtual void Dispose()
        {
        }
    }
}