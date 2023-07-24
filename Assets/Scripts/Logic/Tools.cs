using UnityEngine;

public static class Tools
{
    public static T GetRandomEnumValue<T>() where T : System.Enum
    {
        System.Array values = typeof(T).GetEnumValues();
        int index = Random.Range(0, values.Length);
        return (T)values.GetValue(index);
    }
}