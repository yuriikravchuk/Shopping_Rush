using playerStateMachine;
using UnityEngine;

namespace gameStateMachine
{
    public class FinishState : State
    {
        private readonly UI _ui;
        private readonly GameObject _conveyor;
        private readonly Animation _cameraAnimation;
        private readonly StateMachine _playerStateMachine;

        public FinishState(UI ui, GameObject conveyor, Animation cameraAnimation, StateMachine playerStateMachine)
        {
            _ui = ui;
            _conveyor = conveyor;
            _cameraAnimation = cameraAnimation;
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
            _cameraAnimation.Play();
            _playerStateMachine.TrySwitchState<DanceState>();
            _ui.ShowFinishUI();
            _conveyor.SetActive(false);
        }

        public override void Exit()
        {

            _cameraAnimation.clip.SampleAnimation(_cameraAnimation.gameObject, 0);
            _cameraAnimation.Stop();
            _ui.HideFinishUI();
            _playerStateMachine.TrySwitchState<DefaultState>();
            _conveyor.SetActive(true);
        }

        public override void UpdateState() { }
    }
}