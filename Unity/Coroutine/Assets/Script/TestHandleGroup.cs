using System;
using System.Collections;
using NCoroutine;
using UnityEngine;
using Coroutine = NCoroutine.Coroutine;

namespace DefaultNamespace
{
    public sealed class TestHandleGroup : MonoBehaviour
    {
        private HandleGroup Group;
        private CoroutineHandle h;

        private void Start()
        {
            Group = new HandleGroup();
            var w1 = Coroutine.Run(Wait1());
            var w2 = Coroutine.Run(Wait2());
            var w3 = h = Coroutine.Run(Wait3());
            var w4 = Coroutine.Run(StopWait3(h));
            Group.Add(w1);
            Group.Add(w2);
            Group.Add(w3);
            Group.Add(w4);
            Coroutine.Run(WaitGroup());
        }

        private IEnumerator WaitGroup()
        {
            yield return Group.WaitAll();
            Debug.Log("Group");
            yield break;
        }

        private IEnumerator Wait1()
        {
            yield return new WaitForTime(1f);
            Debug.Log("1F");
            yield break;
        }

        private IEnumerator Wait2()
        {
            yield return new WaitForTime(2f);
            Debug.Log("2F");
            yield break;
        }

        private IEnumerator Wait3()
        {
            yield return new WaitForTime(3f);
            Debug.Log("3f");
            yield break;
        }

        private IEnumerator StopWait3(CoroutineHandle handle)
        {
            Coroutine.Stop(handle);
            Debug.Log("stop");
            var hh = Coroutine.Run(Wait5F());
            Group.Add(hh);
            //Group.Remove(hh);
            yield break;
        }

        private IEnumerator Wait5F()
        {
            yield return new WaitForTime(5f);
            yield break;
        }
    }
}