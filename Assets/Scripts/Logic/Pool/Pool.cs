using pool;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : IObjectProvider<T> where T : Behaviour
{
    public abstract T Get(Func<T, bool> predicate = null);
    protected readonly List<T> Objects;
    private readonly Transform _parent;

    public Pool(Transform parent = null)
    {
        Objects = new List<T>();
        _parent = parent ?? new GameObject(typeof(MultiObjectsPool<T>).Name).transform;
    }

    public void ReturnAll()
    {
        foreach (var element in Objects)
            element.gameObject.SetActive(false);
    }

    public void Clear()
    {
        foreach (var element in Objects)
            UnityEngine.Object.Destroy(element.gameObject);

        Objects.Clear();
    }

    public void Add(T element)
    {
        Objects.Add(element);
        element.transform.SetParent(_parent);
    }

    protected T Instantiate(T prefab)
    {
        T element = UnityEngine.Object.Instantiate(prefab);
        Add(element);
        return element;
    }
}
