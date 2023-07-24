using product;
using System;

public class Mission
{
    public ProductType ProductType { get; private set; }
    public int ProgressCount { get; private set; }
    public int MaxProductsCount { get; private set; }
    public event Action Completed;

    public void Set(ProductType type, int maxProductsCount)
    {
        ProgressCount = 0;
        ProductType = type;
        MaxProductsCount = maxProductsCount;
    }

    public void OnProductCollected()
    {
        ProgressCount++;

        if (ProgressCount >= MaxProductsCount)
            Completed.Invoke();
    }
}