﻿using System;
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
        UnityEngine.Coroutine cor;

        private void Start()
        {
            //selfStopSelf = Coroutine.Run(SelfStopSelf());
            // //这里的顺序不同会有不同的表现,所以具体的逻辑不能依赖协程的执行顺序
            // stopOther = Coroutine.Run(Other());
            // Coroutine.Run(StopOther());
            //TestAwait();
            // StartCoroutine(Run1());
            // StartCoroutine(Run2());
            selfStopSelf = Coroutine.Run(Run1());
            Coroutine.Run(Run2());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                // selfStopSelf = Coroutine.Run(Run1());
                // Coroutine.Run(Run2());
                StartCoroutine(Run1());
                StartCoroutine(Run2());

                // cor = StartCoroutine(Run11());
                // StartCoroutine(Run22());
            }
        }

        private IEnumerator Run1()
        {
            Debug.Log("Run1");
            Debug.Log("r1 " + Time.frameCount);

            yield break;
        }

        private IEnumerator Run2()
        {
            yield return NCoroutine.Coroutine.Run(Run1());
            yield return NCoroutine.Coroutine.Run(Run1());
            yield return NCoroutine.Coroutine.Run(Run1());
            yield return NCoroutine.Coroutine.Run(Run1());
            yield return NCoroutine.Coroutine.Run(Run1());
            Debug.Log("Run2");
            Debug.Log("r2 " + Time.frameCount);

            yield break;
        }

        private IEnumerator Run11()
        {
            Debug.Log("Run1");
            Debug.Log("r11 " + Time.frameCount);

            yield break;
        }

        private IEnumerator Run22()
        {
            yield return cor;
            Debug.Log("Run2");
            Debug.Log("r22 " + Time.frameCount);

            yield break;
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
            yield return null;
            Coroutine.Stop(selfStopSelf);
            Debug.Log("StopSelf");
            yield return WaitPredicate.Create(() =>
            {
                timerr += Time.deltaTime;

                return timerr < 2;
            });


            yield break;
        }

        private float timerr;
    }
}