using System.Collections;
using System.Collections.Generic;

namespace NCoroutine
{
    public sealed class HandleGroup
    {
        private List<CoroutineHandle> handles = new List<CoroutineHandle>();
        private List<CoroutineHandle> waitAdd = new List<CoroutineHandle>();
        private List<CoroutineHandle> waitRemove = new List<CoroutineHandle>();

        public IEnumerator WaitAll()
        {
            WaitPredicate predicate = WaitPredicate.Create(UpdateAll);
            yield return predicate;
            NReferencePool.ReferencePool.Release(predicate);
        }

        public IEnumerator WaitAny()
        {
            WaitPredicate predicate = WaitPredicate.Create(UpdateAny);
            yield return predicate;
            NReferencePool.ReferencePool.Release(predicate);
        }

        public void Add(CoroutineHandle handle)
        {
            waitAdd.Add(handle);
        }

        public void Remove(CoroutineHandle handle)
        {
            waitRemove.Add(handle);
        }

        private void UpdateAfter()
        {
            if (waitAdd.Count > 0)
            {
                handles.AddRange(waitAdd);
                waitAdd.Clear();
            }

            if (waitRemove.Count > 0)
            {
                foreach (CoroutineHandle handle in waitRemove)
                {
                    handles.Remove(handle);
                }

                waitRemove.Clear();
            }
        }

        private bool UpdateAny()
        {
            UpdateAfter();
            if (handles.Count < 1)
            {
                return false;
            }

            foreach (CoroutineHandle handle in handles)
            {
                if (handle.driver == null || handle.driver.isComplete)
                {
                    return false;
                }
            }

            return true;
        }


        private bool UpdateAll()
        {
            UpdateAfter();
            foreach (CoroutineHandle handle in handles)
            {
                if (handle.driver != null && !handle.driver.isComplete)
                {
                    return true;
                }
            }

            return false;
        }
    }
}