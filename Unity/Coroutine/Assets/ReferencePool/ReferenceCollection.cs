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
            references = new Queue<IReference>(4);
            this.referenceType = referenceType;
            checkType = true;
        }

        public T Acquire<T>() where T : class, IReference, new()
        {
            if (typeof(T) != referenceType) throw new ArgumentException("Type Error");

            if (references.Count > 0) return (T) references.Dequeue();

            return new T();
        }

        public IReference Acquire()
        {
            if (references.Count > 0) return references.Dequeue();
            return (IReference) Activator.CreateInstance(referenceType);
        }

        public void Release(IReference reference)
        {
            reference.Clear();
            if (checkType && references.Contains(reference)) throw new ArgumentException("Repeated release");

            references.Enqueue(reference);
        }
    }
}