using System;
using NReferencePool;

namespace NCoroutine
{
    public sealed class WaitPredicate : BaseWait, IReference
    {
        private Func<bool> predicate;

        public static WaitPredicate Create(Func<bool> predicate)
        {
            WaitPredicate waitPredicate = ReferencePool.Acquire<WaitPredicate>();
            waitPredicate.predicate = predicate;
            return waitPredicate;
        }

        public override bool Update()
        {
            return predicate();
        }

        public void Clear()
        {
            predicate = null;
        }
    }
}