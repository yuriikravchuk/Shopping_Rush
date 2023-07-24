using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace playerStateMachine
{
    public class DanceState : State
    {
        private readonly Animator _animator;
        private readonly Rig _rig;

        public DanceState(Animator animator, Rig rig)
        {
            _animator = animator;
            _rig = rig;
        }

        public override bool CanTransit(State state)
        {
            return state switch
            {
                DefaultState => true,
                _ => false,
            };
        }

        public override void Enter()
        {
            _rig.weight = 0f;
            _animator.SetBool("dancing", true);
        }

        public override void Exit()
        {
            _rig.weight = 1f;
            _animator.SetBool("dancing", false);
        }

        public override void UpdateState() { }
    }
}