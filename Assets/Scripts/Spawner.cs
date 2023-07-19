using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 3f;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private GameObject _prefab;

    private float _lastSpawnedTime;

    private void OnValidate()
    {
        if(_spawnRate < 0)
            _spawnRate = 0;
    }

    private void Start()
    {
        _lastSpawnedTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time > _lastSpawnedTime + _spawnRate)
        {
            Instantiate(_prefab, _spawnTransform.position, Quaternion.identity);
            _lastSpawnedTime = Time.time;
        }
    }
}