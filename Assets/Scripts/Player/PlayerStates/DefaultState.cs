using product;
using UnityEngine;

namespace playerStateMachine
{
    public class DefaultState : State
    {
        private readonly Animator _animator;
        private readonly HandGrip _handGrip;
        private readonly MissionPresenter _mission;

        public DefaultState(Animator animator, HandGrip handGrip, MissionPresenter mission)
        {
            _animator = animator;
            _handGrip = handGrip;
            _mission = mission;
            _handGrip.Picked += CheckProduct;
        }

        public override bool CanTransit(State state)
        {
            return state switch
            {
                DanceState => true,
                _ => false,
            };
        }

        public override void Enter() { }

        public override void Exit() { }

        public override void UpdateState() { }

        public void OnProductSelected(Product product) => _handGrip.PickProduct(product);

        private void CheckProduct(Product product)
        {
            if (product == null)
                return;

            if (product.Type == _mission.ProductType)
                _animator.SetTrigger("collect product");
            else
                _animator.SetTrigger("throw out product"); 
        }
    }
}