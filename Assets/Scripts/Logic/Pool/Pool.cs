using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace pool
{
    public class Pool<T>: IObjectProvider<T> where T : Behaviour
	{
		private readonly List<T> _objects;
		private readonly Transform _parent;

		public Pool(Transform parent){
            _objects = new List<T>();
			_parent = parent;
        }

		public T Get(Func<T, bool> predicate = null)
        {
            T element = _objects.Where((predicate ?? (item => true)))
				.FirstOrDefault(item => item.isActiveAndEnabled == false);

			element?.gameObject.SetActive(true);
            return element;
        }

        public void ReturnAll()
		{
			foreach(var element in _objects)
				element.gameObject.SetActive(false);
		}

		public void Clear()
        {
			foreach (var element in _objects)
                UnityEngine.Object.Destroy(element.gameObject);

			_objects.Clear();
		}

		public void Add(T element)
		{
            _objects.Add(element);
			//element.gameObject.SetActive(false);
			element.transform.SetParent(_parent);
        }
    }
}