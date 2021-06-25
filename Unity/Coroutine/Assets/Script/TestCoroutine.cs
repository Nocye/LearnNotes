using System.Collections;
using NCoroutine;
using UnityEngine;
using Coroutine = NCoroutine.Coroutine;

namespace DefaultNamespace
{
    public class TestCoroutine : MonoBehaviour
    {
        public GameObject Obj;
        private CoroutineHandle handle;

        private void Start()
        {
            //Coroutine.Run(WaitMove());
        }

        private void OnGUI()
        {
            Vector2 buttonSize = new Vector2(200, 100);
            Rect doMoveRect = new Rect(Vector2.zero, buttonSize);
            Rect waitMoveRect = new Rect(new Vector2(0, doMoveRect.y + 100), buttonSize);
            Rect stopRect = new Rect(new Vector2(0, waitMoveRect.y + 100), buttonSize);
            if (GUI.Button(doMoveRect, "DoMove")) handle = Coroutine.Run(DoMove(Obj.transform.position.x, 5, 2));

            if (GUI.Button(waitMoveRect, "WaitDoMoveAndBack")) handle = Coroutine.Run(WaitMove());

            if (GUI.Button(stopRect, "Stop")) Coroutine.Stop(handle);
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