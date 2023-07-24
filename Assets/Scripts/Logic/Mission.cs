using UnityEngine;
using product;
using System;

public class Mission : MonoBehaviour
{
    [SerializeField] private MissionView _view;

    public ProductType ProductType { get; private set; }
    public event Action Completed;

    private int _maxProductsCount;
    private int _progressCount;

    public void Init(ProductType type, int maxProductsCount)
    {
        ProductType = type;
        _maxProductsCount = maxProductsCount;
        _progressCount = 0;
        _view.UpdateText(type, maxProductsCount);
    }

    public void OnProductCollected(ProductType productType)
    {
        if (productType != ProductType)
            return;

        _progressCount++;

        if (_progressCount >= _maxProductsCount)
            Completed.Invoke();

        _view.UpdateText(ProductType, _maxProductsCount - _progressCount);
    }
}