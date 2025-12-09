using UnityEngine;
using AI.StateMachines;
using CharacterControllers;

namespace AI.Enemy.State
{
    public class Idle : States
    {
        public Idle(AI ai, CharacterController2D controller) : base(ai, controller)
        {
        }

        public override void EnterState()
        {
            
        }

        public override void ExitState()
        {
        }

        public override void UpdateState()
        {
        }
    }
}