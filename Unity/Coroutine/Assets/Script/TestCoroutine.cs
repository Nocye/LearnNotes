using System.Collections;
using NCoroutine;
using NReferencePool;
using UnityEngine;
using UnityEngine.Networking;
using Coroutine = NCoroutine.Coroutine;

namespace DefaultNamespace
{
    public class TestCoroutine : MonoBehaviour
    {
        public GameObject Obj;

        private CoroutineHandle dayuhandle;
        private CoroutineHandle handle;
        private float timer;

        private void Start()
        {
        }

        private void Update()
        {
        }

        private void OnGUI()
        {
            Vector2 buttonSize = new Vector2(200, 100);
            Rect doMoveRect = new Rect(Vector2.zero, buttonSize);
            Rect waitMoveRect = new Rect(new Vector2(0, doMoveRect.y + 100), buttonSize);
            Rect stopRect = new Rect(new Vector2(0, waitMoveRect.y + 100), buttonSize);
            Rect asyncRect = new Rect(new Vector2(0, stopRect.y + 100), buttonSize);
            Rect cancelNowRect = new Rect(new Vector2(0, asyncRect.y + 100), buttonSize);
            Rect operationRect = new Rect(new Vector2(0, cancelNowRect.y + 100), buttonSize);
            if (GUI.Button(doMoveRect, "DoMove")) handle = Coroutine.Run(DoMove(Obj.transform.position.x, 5, 2));

            if (GUI.Button(waitMoveRect, "WaitDoMoveAndBack")) handle = Coroutine.Run(WaitMove());

            if (GUI.Button(stopRect, "StopMove")) Coroutine.Stop(handle);
            if (GUI.Button(asyncRect, "await")) RunAsync();
            if (GUI.Button(cancelNowRect, "Cancel Now")) CancelNow();
            if (GUI.Button(operationRect, "Operation")) Coroutine.Run(Operation());
        }

        private IEnumerator Operation()
        {
            UnityWebRequest webRequest = UnityWebRequest.Get("http://www.baidu.com/");
            webRequest.timeout = 5;
            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.result);
        }

        private void CancelNow()
        {
            CoroutineHandle h = Coroutine.Run(Cancel());
            Coroutine.Stop(h);
        }

        private IEnumerator Cancel()
        {
            yield return null;
            Debug.Log("VAR");
        }

        private bool Dayu()
        {
            timer += Time.deltaTime;
            return timer < 2f;
        }

        private IEnumerator WaitTime()
        {
            WaitPredicate temp = WaitPredicate.Create(Dayu);
            Debug.Log($"start Time {Time.time}");
            yield return temp;
            Debug.Log($"end time {Time.time}");
            ReferencePool.Release(temp);
            Coroutine.Stop(dayuhandle);
        }

        private async void RunAsync()
        {
            await Coroutine.Run(DoMove(1, 3, 3));
            await Coroutine.Run(WaitMove());
            Debug.Log("Wait Completed");
        }

        private IEnumerator DoMove(float start, float end, float duration)
        {
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                float value = Mathf.Lerp(start, end, elapsedTime / duration);
                Obj.transform.position = new Vector3(value, 0, 0);
                yield return null;
                elapsedTime += Time.deltaTime;
            }

            Obj.transform.position = new Vector3(end, 0, 0);
        }

        private IEnumerator WaitMove()
        {
            yield return DoMove(0, 5, 2);
            float elapsedTime = 0f;
            Transform objTransform = Obj.transform;
            Vector3 startPosition = objTransform.position;
            while (elapsedTime < 2f)
            {
                objTransform.position = Vector3.Lerp(startPosition, Vector3.zero, elapsedTime / 2);
                yield return null;
                elapsedTime += Time.deltaTime;
            }

            objTransform.position = Vector3.zero;
        }
    }
}