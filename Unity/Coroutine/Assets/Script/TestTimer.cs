using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace DefaultNamespace
{
    public class TestTimer : MonoBehaviour
    {
        private Timer.Timer timer = new global::Timer.Timer();

        private void Start()
        {
            Debug.Log($"Current : {Time.time}");
            for (int i = 0; i < 4; i++)
            {
                timer.AddDelayTask(() => { Debug.Log("Start"); }, 2f);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                int r = Random.Range(1, 4);
                var t = Time.time + r;
                var tm = Time.time;
                timer.AddDelayTask(() => { Debug.Log($"Updata : {t} Time: {tm} Delay: {r}"); }, r);
            }

            timer.Update();
        }
    }
}