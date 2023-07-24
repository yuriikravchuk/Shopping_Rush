using playerStateMachine;
using UnityEngine;

namespace gameStateMachine
{
    public class FinishState : State
    {
        private readonly UI _ui;
        private readonly GameObject _conveyor;
        private readonly Transform _camera;
        private readonly StateMachine _playerStateMachine;

        public FinishState(UI ui, GameObject conveyor, Transform camera, StateMachine playerStateMachine)
        {
            _ui = ui;
            _conveyor = conveyor;
            _camera = camera;
            _playerStateMachine = playerStateMachine;
        }

        public override bool CanTransit(State state)
        {
            return state switch
            {
                MenuState => true,
                PlayState => true,
                _ => false,
            };
        }

        public override void Enter()
        {
            // move camera
            _playerStateMachine.TrySwitchState<DanceState>();
            _ui.ShowFinishUI();
            _conveyor.SetActive(false);
        }

        public override void Exit()
        {
            _ui.HideFinishUI();
            _playerStateMachine.TrySwitchState<DefaultState>();
            //move camera back
            _conveyor.SetActive(true);
        }

        public override void UpdateState() { }
    }
}