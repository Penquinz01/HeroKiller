using UnityEngine;

namespace AI.StateMachines
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

        public void Update()
        {
            currentState?.UpdateState();
        }

        public void FixedUpdate()
        {
            currentState?.FixedUpdateState();
        }
    }
}