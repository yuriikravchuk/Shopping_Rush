using pool;
using System.Linq;
using UnityEngine;

namespace product
{
    public class ProductsProvider : MonoBehaviour
    {
        [SerializeField] private ProductsConfig _config;

        private Pool<Product> _pool;

        private void Awake() => _pool = new Pool<Product>(transform);

        public Product Get(ProductType type) =>
            _pool.Get((item) => item.Type == type) ?? InstantiateProduct(type);

        public void ReturnAll() => _pool.ReturnAll();

        private Product InstantiateProduct(ProductType type)
        {
            Product prefab = _config.Products.First(item => item.Type == type);
            Product product = Instantiate(prefab, transform);
            _pool.Add(product);
            return product;
        }
    }
}