using System;
using System.Collections.Generic;

namespace NReferencePool
{
    public static partial class ReferencePool
    {
        private static readonly Dictionary<Type, ReferenceCollection> referenceCollections =
            new Dictionary<Type, ReferenceCollection>();

        public static T Acquire<T>() where T : class, IReference, new()
        {
            return GetReferenceCollection(typeof(T)).Acquire<T>();
        }

        public static IReference Acquire(Type referenceType)
        {
            InternalCheckReferenceType(referenceType);
            return GetReferenceCollection(referenceType).Acquire();
        }

        public static void Release(IReference reference)
        {
            Type referenceType = reference.GetType();
            InternalCheckReferenceType(referenceType);
            GetReferenceCollection(referenceType).Release(reference);
        }

        private static void InternalCheckReferenceType(Type referenceType)
        {
            if (!referenceType.IsClass || referenceType.IsAbstract)
            {
                throw new ArgumentException("Reference type is not a non-abstract class type");
            }

            if (!typeof(IReference).IsAssignableFrom(referenceType))
            {
                throw new ArgumentException($"{referenceType.FullName} is is invalid");
            }
        }

        private static ReferenceCollection GetReferenceCollection(Type referenceType)
        {
            if (!referenceCollections.TryGetValue(referenceType, out ReferenceCollection collection))
            {
                collection = new ReferenceCollection(referenceType);
                referenceCollections.Add(referenceType, collection);
            }

            return collection;
        }
    }
}