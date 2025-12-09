using System;
using UnityEngine;
using AI;
using AI.StateMachines;
using CharacterControllers;


namespace AI.Enemy
{
    public class Enemy:MonoBehaviour
    {
        [SerializeField] private bool _playable;

        private StateMachine _stateMachine;
        private AI ai;
        private CharacterController2D controller;

        private void Awake()
        {
            
            controller = GetComponent<CharacterController2D>();
            _stateMachine = new EnemyStateMachine(ai,controller);
        }

        
    }
}