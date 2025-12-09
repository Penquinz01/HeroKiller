using UnityEngine;

namespace AI.StateMachine
{
    public class StateMachine
    {
        private States currentState = null;

        public void SwitchState(States newState)
        {
            currentState?.ExitState();
            currentState = newState;
            currentState.EnterState();
        }
    }
}