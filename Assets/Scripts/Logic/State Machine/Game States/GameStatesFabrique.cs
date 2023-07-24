using System.Collections.Generic;
using UnityEngine;

namespace gameStateMachine
{
    public class GameStatesFabrique : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private UI _ui;
        [SerializeField] private GameObject _productsSpawner;
        [SerializeField] private MissionPresenter _mission;
        [SerializeField] private GameObject _furniture;
        [SerializeField] private Animation _cameraAnimation;
        [SerializeField] private StateMachine _playerStateMachine;

        public void Awake()
        {
            var menuState = new MenuState(_ui);
            var playState = new PlayState(_ui, _productsSpawner, _mission);
            var finishState = new FinishState(_ui, _furniture, _cameraAnimation, _playerStateMachine);
            var states = new List<State> { menuState, playState, finishState };
            _stateMachine.Init(states, startState: menuState);
        }
    }
}