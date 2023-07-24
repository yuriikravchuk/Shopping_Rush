using product;
using UnityEngine;

namespace gameStateMachine
{
    public class PlayState : State
    {
        private readonly UI _ui;
        private readonly MissionGenerator _missionGenerator;
        private readonly MissionPresenter _mission;
        private readonly GameObject _productsSpawner;

        public PlayState(UI ui, GameObject productsSpawner, MissionPresenter mission)
        {
            _ui = ui;
            _productsSpawner = productsSpawner;
            _missionGenerator = new MissionGenerator(minProductsCount: 1, maxProductsCount: 5);
            _mission = mission;
        }

        public override bool CanTransit(State state)
        {
            return state switch
            {
                FinishState => true,
                _ => false,
            };
        }

        public override void Enter()
        {
            _missionGenerator.GetMission(out ProductType type, out int count);
            _mission.Set(type, count);
            _ui.ShowPlayUI();
            _productsSpawner.SetActive(true);
        }

        public override void Exit()
        {
            _ui.HidePlayUI();
            _productsSpawner.SetActive(false);
        }

        public override void UpdateState() { }
    }
}