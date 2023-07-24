using gameStateMachine;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private StateMachine _gameStateMachine;
    [SerializeField] private UI _ui;
    [SerializeField] private Mission _mission;
    [SerializeField] private Cart _cart;

    private void Awake()
    {
        _ui.PlayButtonClicked += () => _gameStateMachine.TrySwitchState<PlayState>();
        _mission.Completed += () => _gameStateMachine.TrySwitchState<FinishState>();
        _ui.NextLevelButtonClicked += () => _gameStateMachine.TrySwitchState<PlayState>();
        _cart.ProductCollected += _mission.OnProductCollected;
    }
}