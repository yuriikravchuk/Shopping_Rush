using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace pool
{
    public class MultiObjectsPool<T>: Pool<T>, IObjectProvider<T> where T : Behaviour
	{
        private readonly IReadOnlyList<T> _prefabs;

        public MultiObjectsPool(IReadOnlyList<T> prefabs) => _prefabs = prefabs;

        public override T Get(Func<T, bool> predicate = null)
        {
            predicate ??= item => true;

            T element = Objects.Where(predicate)
				.FirstOrDefault(item => item.isActiveAndEnabled == false)
                ?? Instantiate(_prefabs.First(predicate));

            element?.gameObject.SetActive(true);
            return element;
        }
    }
}