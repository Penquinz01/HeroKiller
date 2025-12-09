using UnityEngine;
using AI.StateMachines;
using AI.Enemy.State;
using CharacterControllers;

namespace AI.Enemy
{
    public class EnemyStateMachine:StateMachine
    {
        
        Idle _idleState;
        Moving _moving;
        JumpStart _jumpStart;
        InAir _inAir;
        JumpEnd _jumpEnd;
        AttackStart _attackStart;
        InAttack _Attack;
        AttackEnd _attackEnd;

        public EnemyStateMachine(AI ai,CharacterController2D controller)
        {
            _idleState = new Idle(ai,controller);
            _moving = new Moving(ai,controller);
            _jumpStart = new JumpStart(ai,controller);
            _inAir = new InAir(ai,controller);
            _jumpEnd = new JumpEnd(ai,controller);
            _attackStart = new AttackStart(ai,controller);
            _Attack = new InAttack(ai,controller);
            _attackEnd = new AttackEnd(ai,controller);
        }
    }
}