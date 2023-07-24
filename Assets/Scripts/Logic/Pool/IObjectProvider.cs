using System;

public interface IObjectProvider<T>
{
	T Get(Func<T, bool> predicate = null);
}