using gameStateMachine;
using product;
using UnityEngine;
using pool;

public class Starter : MonoBehaviour
{
    [SerializeField] private StateMachine _gameStateMachine;
    [SerializeField] private UI _ui;
    [SerializeField] private MissionPresenter _mission;
    [SerializeField] private Cart _cart;
    [SerializeField] private ProductsConfig _config;
    [SerializeField] private ProductsSpawner _spawner;

    private void Awake()
    {
        InitGameStateMachine();
        _cart.ProductCollected += _mission.OnProductCollected;
        _spawner.Init(new MultiObjectsPool<Product>(_config.Products));
    }

    private void InitGameStateMachine()
    {
        _ui.PlayButtonClicked += () => _gameStateMachine.TrySwitchState<PlayState>();
        _mission.Completed += () => _gameStateMachine.TrySwitchState<FinishState>();
        _ui.NextLevelButtonClicked += () => _gameStateMachine.TrySwitchState<PlayState>();
    }
}