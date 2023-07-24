using System.Collections.Generic;
using UnityEngine;

namespace product
{
    [CreateAssetMenu(fileName = "ProductsConfig", menuName = "My Assets/ProductsConfig")]
    public class ProductsConfig : ScriptableObject
    {
        [SerializeField] private List<Product> _products;

        public IReadOnlyList<Product> Products => _products;
    }
}