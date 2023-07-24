using product;
using UnityEngine;

public class ProductsSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 2f;
    
    private IObjectProvider<Product> _provider;
    private float _lastSpawnedTime;

    public void Init(IObjectProvider<Product> provider) 
        => _provider = provider;

    private void OnValidate()
    {
        if(_spawnRate < 0)
            _spawnRate = 0;
    }

    private void OnEnable() => _lastSpawnedTime = 0;


    private void FixedUpdate() => TrySpawn();

    private void TrySpawn()
    {
        if (Time.time > _lastSpawnedTime + _spawnRate)
        {
            ProductType productType = Tools.GetRandomEnumValue<ProductType>();
            Product product = _provider.Get(item => item.Type == productType);
            product.transform.position = transform.position;
            _lastSpawnedTime = Time.time;
        }
    }
}