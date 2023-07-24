namespace gameStateMachine
{
    public class MenuState : State
    {
        private readonly UI _ui;

        public MenuState(UI ui) => _ui = ui;

        public override bool CanTransit(State state)
        {
            switch (state)
            {
                case PlayState:
                    return true;

                default:
                    return false;
            }
        }

        public override void Enter() => _ui.ShowMenuUI();

        public override void Exit() => _ui.HideMenuUI();

        public override void UpdateState() { }
    }
}

