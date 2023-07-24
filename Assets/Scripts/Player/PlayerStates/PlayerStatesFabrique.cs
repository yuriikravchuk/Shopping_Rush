using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace playerStateMachine
{
    public class PlayerStatesFabrique : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private Animator _animator;
        [SerializeField] private HandGrip _handGrip;
        [SerializeField] private Rig _rig;
        [SerializeField] private MissionPresenter _mission;
        [SerializeField] private PlayerInput _productSelector;

        private void Awake()
        {
            var playState = new DefaultState(_animator, _handGrip, _mission);
            var danceState = new DanceState(_animator, _rig);
            var states = new List<State> { playState, danceState };
            _productSelector.ProductSelected += playState.OnProductSelected;
            _stateMachine.Init(states, startState: playState);
        }
    }
}