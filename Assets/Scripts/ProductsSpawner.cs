using product;
using UnityEngine;

public class ProductsSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private ProductsProvider _provider;

    private float _lastSpawnedTime;

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
            Product product = _provider.Get(Tools.GetRandomEnumValue<ProductType>());
            product.transform.position = transform.position;
            _lastSpawnedTime = Time.time;
        }
    }
}