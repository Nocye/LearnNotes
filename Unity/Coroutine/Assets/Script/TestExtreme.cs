using System;
using System.Collections;
using UnityEngine;
using NCoroutine;
using Coroutine = NCoroutine.Coroutine;

namespace DefaultNamespace
{
    public class TestExtreme : MonoBehaviour
    {
        private CoroutineHandle selfStopSelf;
        private CoroutineHandle stopOther;
        private CoroutineHandle awaitTest;

        private void Start()
        {
            // selfStopSelf = Coroutine.Run(SelfStopSelf());
            // //这里的顺序不同会有不同的表现,所以具体的逻辑不能依赖协程的执行顺序
            // stopOther = Coroutine.Run(Other());
            // Coroutine.Run(StopOther());
            TestAwait();
        }

        private async void TestAwait()
        {
            Debug.Log($"Start Frame = {Time.frameCount}");
            //await awaitTest;
            Debug.Log($"Await null Frame={Time.frameCount}");
            await (awaitTest = Coroutine.Run(Await()));
            Debug.Log($"AwaitEnd Frame={Time.frameCount}");
        }

        private IEnumerator Await()
        {
            yield return new WaitForTime(1f);
            Debug.Log("Coroutine ing");
            Coroutine.Stop(awaitTest);
            yield return null;
            Debug.Log($"Ing= Frame={Time.frameCount}");
            yield break;
        }

        private IEnumerator StopOther()
        {
            yield return null;
            Coroutine.Stop(stopOther);
            Debug.Log("StopOther");
            yield break;
        }

        private IEnumerator Other()
        {
            yield return null;
            Debug.Log("Other");
            yield break;
        }

        private IEnumerator SelfStopSelf()
        {
            yield return new WaitForTime(1f);
            Coroutine.Stop(selfStopSelf);
            Debug.Log("StopSelf");
            yield return null;
            yield break;
        }
    }
}