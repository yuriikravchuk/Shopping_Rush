using product;
using System;
using UnityEngine;

public class MissionPresenter : MonoBehaviour
{
    [SerializeField] private MissionView _view;

    public event Action Completed
    {
        add => _model.Completed += value;
        remove => _model.Completed -= value;
    }

    public ProductType ProductType => _model.ProductType;

    private Mission _model = new();

    public void Set(ProductType type, int maxProductsCount)
    {
        _model.Set(type, maxProductsCount);
        _view.UpdateText(type, maxProductsCount);
    }

    public void OnProductCollected(ProductType productType)
    {
        if (productType != _model.ProductType)
            return;

        _model.OnProductCollected();

        _view.UpdateText(_model.ProductType, _model.MaxProductsCount - _model.ProgressCount);
        _view.PlayCollectedAnimation();
    }
}
