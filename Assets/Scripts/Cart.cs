using product;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public event Action<ProductType> ProductCollected;

    private List<Product> _products;

    private void OnEnable() => _products = new List<Product>();

    private void OnTriggerEnter(Collider other)
    {
        Product product = other.GetComponent<Product>();

        if (product == null || _products.Contains(product))
            return;

        _products.Add(product);
        ProductCollected.Invoke(product.Type);
    }
}