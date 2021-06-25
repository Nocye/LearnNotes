using System;
using UnityEngine;

namespace NCoroutine
{
    [AddComponentMenu("")]
    public class CoroutineDevice : MonoBehaviour
    {
        internal Action<float> coroutineUpdate;

        private void Update()
        {
            coroutineUpdate?.Invoke(Time.deltaTime);
        }
    }
}