using UnityEngine;
using CharacterControllers;

namespace AI.StateMachines
{
    public abstract class States
    {
        protected AI ai;
        protected CharacterController2D controller;

        public States(AI ai,CharacterController2D controller)
        {
            this.ai = ai;
            this.controller = controller;
        }
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        public virtual void FixedUpdateState(){}
        public virtual void LateUpdateState(){}
    }
}


