using System;
using System.Collections;
using NCoroutine;
using UnityEngine;
using Coroutine = NCoroutine.Coroutine;
using Random = UnityEngine.Random;


namespace DefaultNamespace
{
    public class TestTimer : MonoBehaviour
    {
        private Timer.Timer timer = new global::Timer.Timer();

        private void Start()
        {
            // Debug.Log($"Current : {Time.time}");
            // for (int i = 0; i < 4; i++)
            // {
            //     timer.StartTask(() => { Debug.Log("Start"); }, 2f);
            // }
            // Debug.Log(0 + "|||||||" + Time.frameCount);
            // StartCoroutine(cor1());
            // Coroutine.Run(cor1());
            //StopCoroutine(g);s

        }

        private UnityEngine.Coroutine h123;

        private IEnumerator cor1()
        {
           
            Debug.Log(Time.frameCount);
            yield break;
        }

        private IEnumerator cor2()
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Over");
            yield break;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log(0 + "|||||||" + Time.frameCount);
                StartCoroutine(cor1());
                Coroutine.Run(cor1());
                // int r = Random.Range(1, 4);
                // var t = Time.time + r;
                // var tm = Time.time;
                // Debug.Log(Time.time);
                // var handle =
                //     timer.StartTask(() => { Debug.Log($"Updata : {t} Time: {tm} Delay: {r} Current:{Time.time}"); }, r);
                // timer.StopTask(handle);
            }

            timer.Update();
        }
    }
}