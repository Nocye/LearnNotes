using System;
using System.Collections;
using System.Threading.Tasks;
using NCoroutine;
using NReferencePool;
using UnityEngine;
using UnityEngine.Networking;
using Coroutine = NCoroutine.Coroutine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TestCoroutine : MonoBehaviour
    {
        public GameObject Obj;

        private CoroutineHandle dayuhandle;
        private CoroutineGroup group;
        private CoroutineHandle handle;
        private float timer;
        private UnityEngine.Coroutine uc;

        private void Start()
        {
            group = CoroutineGroup.Create(new Func<IEnumerator>[] {Group1, Group2, Group3});
            dayuhandle =  Coroutine.Run(TestCancel());
        }

        private async void Runnn()
        {
            Debug.Log(Time.frameCount);

            await Coroutine.Run(TestCancel());
            Debug.Log(Time.frameCount);
        }

        private IEnumerator TestCancel()
        {
            yield return new WaitForTime(0.5f);
            Coroutine.Stop(dayuhandle);
            Debug.Log("0.5f");
        }

        private IEnumerator cccan()
        {
            yield return new WaitForTime(0.5f);
            Debug.Log("2D");
            yield break;
        }

        private void Update()
        {
        }

        private void OnGUI()
        {
            Vector2 buttonSize = new Vector2(200, 50);
            Rect doMoveRect = new Rect(Vector2.zero, buttonSize);
            Rect waitMoveRect = new Rect(new Vector2(0, doMoveRect.y + 50), buttonSize);
            Rect stopRect = new Rect(new Vector2(0, waitMoveRect.y + 50), buttonSize);
            Rect asyncRect = new Rect(new Vector2(0, stopRect.y + 50), buttonSize);
            Rect cancelNowRect = new Rect(new Vector2(0, asyncRect.y + 50), buttonSize);
            Rect operationRect = new Rect(new Vector2(0, cancelNowRect.y + 50), buttonSize);
            Rect groupAnyRect = new Rect(new Vector2(0, operationRect.y + 50), buttonSize);
            Rect groupAllRect = new Rect(new Vector2(0, groupAnyRect.y + 50), buttonSize);
            if (GUI.Button(doMoveRect, "DoMove")) handle = Coroutine.Run(DoMove(Obj.transform.position.x, 5, 2));

            if (GUI.Button(waitMoveRect, "WaitDoMoveAndBack")) handle = Coroutine.Run(WaitMove());

            if (GUI.Button(stopRect, "StopMove")) Coroutine.Stop(handle);
            if (GUI.Button(asyncRect, "Use Await")) RunAsync();
            if (GUI.Button(cancelNowRect, "Cancel Now")) CancelNow();
            if (GUI.Button(operationRect, "Operation")) Coroutine.Run(Operation());
            if (GUI.Button(groupAnyRect, "GroupWaitAny")) Coroutine.Run(GroupWaitAny());

            if (GUI.Button(groupAllRect, "GroupWaitAll")) Coroutine.Run(GroupWaitAll());
        }

        private IEnumerator Group1()
        {
            yield return new WaitForTime(Random.Range(0, 1));
            Debug.Log(nameof(Group1));
        }

        private IEnumerator Group2()
        {
            float duration = 2;
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                float value = Mathf.Lerp(0, 2, elapsedTime / 2);
                yield return null;
                elapsedTime += Time.deltaTime;
            }

            Debug.Log(elapsedTime);
        }

        private IEnumerator Group3()
        {
            yield return Operation();
        }

        private IEnumerator GroupWaitAny()
        {
            yield return group.Run().WaitAny();
            Debug.Log("WaitAny");
            yield return @group.WaitAll();
            Debug.Log("all");
        }

        private IEnumerator GroupWaitAll()
        {
            yield return group.Run().WaitAll();
            Debug.Log("WaitAll");
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
            dayuhandle = Coroutine.Run(TestCancel());
            //Coroutine.Stop(h);
        }

        private IEnumerator Cancel()
        {
            yield return null;
            Debug.Log("VAR");
        }

        private bool Predicate()
        {
            timer += Time.deltaTime;
            return timer < 2f;
        }

        private IEnumerator WaitTime()
        {
            WaitPredicate temp = WaitPredicate.Create(Predicate);
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