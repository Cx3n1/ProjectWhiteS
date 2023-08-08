using System;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace StateMachine.SpiderStateMachine
{
    public class SpiderStateMachine : StateMachine
    {
        private SpiderBrain _brain;
        public SpiderBrain Brain => _brain;

        public Rigidbody SpiderBody { get; private set; }
        public SpiderInfo Spider { get; private set; }

        // States goes here
        public readonly SpiderState Idle = new Idle();
        public readonly SpiderState Move = new Move();
        public readonly SpiderState Jump = new Jump();
        public readonly SpiderState InAir = new InAir();
        public readonly SpiderState Land = new Land();
        // States go above


        public SpiderStateMachine()
        {
            // Start state goes here
            BaseState = InAir;
        }
        
        private void Awake()
        {// we use Awake because we can't use start as it is used in StateMachine (parent of this class)
            // we get brain component from awake because we can't do it from constructor
            // we need brain to be accessible to all states so we put it in state machine
            _brain = GetComponent<SpiderBrain>();
            Spider = GetComponent<SpiderInfo>();
            SpiderBody = GetComponent<Rigidbody>();
        }
        
        
        
        //___Utility___\\
        
        /// <summary>
        /// Down casts given StateMachine to SpiderStateMachine
        /// </summary>
        /// <param name="stateMachine">SpiderStateMachine referenced as StateMachine</param>
        /// <returns>StateMachine Down casted to SpiderStateMachine</returns>
        public static SpiderStateMachine ToSpider(StateMachine stateMachine) => (SpiderStateMachine)stateMachine;

        
    }
}

