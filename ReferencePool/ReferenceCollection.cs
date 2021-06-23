using System;
using System.Collections.Generic;

namespace NReferencePool
{
    internal sealed class ReferenceCollection
    {
        private readonly Queue<IReference> references;
        private readonly Type referenceType;
        private readonly bool checkType;

        public ReferenceCollection(Type referenceType)
        {
            references = new Queue<IReference>();
            this.referenceType = referenceType;
            checkType = true;
        }

        public T Acquire<T>() where T : class, IReference, new()
        {
            if (typeof(T) != referenceType) throw new ArgumentException("Type Error");

            if (references.Count > 0) return (T) references.Dequeue();

            return new T();
        }

        public void Release(IReference reference)
        {
            reference.Clear();
            if (checkType && references.Contains(reference)) throw new ArgumentException("Repeated release");

            references.Enqueue(reference);
        }
    }
}