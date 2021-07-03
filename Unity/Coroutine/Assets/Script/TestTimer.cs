using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TestTimer : MonoBehaviour
    {
        private PriorityQueue timer = new PriorityQueue();

        private void Start()
        {
            Debug.Log($"Current : {Time.time}");
            timer.Enqueue(() => { Debug.Log("Start"); }, Time.time + 2f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                int r = Random.Range(1, 4);
                var t = Time.time + r;
                var tm = Time.time;
                timer.Enqueue(() => { Debug.Log($"Updata : {t} Time: {r}"); }, t);
            }

            timer.Update(Time.time);
        }
    }
}