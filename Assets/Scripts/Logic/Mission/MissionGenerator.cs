using product;
using UnityEngine;

public class MissionGenerator
{
    private readonly int _minProductsCount;
    private readonly int _maxProductsCount;

    public MissionGenerator(int minProductsCount, int maxProductsCount)
    {
        _minProductsCount = Mathf.Max(minProductsCount, 1);
        _maxProductsCount = Mathf.Max(maxProductsCount, _minProductsCount);
    }

    public void GetMission(out ProductType type, out int count)
    {
        type = Tools.GetRandomEnumValue<ProductType>();
        count = Random.Range(_minProductsCount, _maxProductsCount);
    }
}