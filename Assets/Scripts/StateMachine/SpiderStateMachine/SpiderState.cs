using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace StateMachine.SpiderStateMachine
{
    public abstract class SpiderState : State
    {
        /// <summary>
        /// Reference to current state machine in which this state is active (current state)
        /// </summary>
        protected SpiderStateMachine SSM { get; private set; }

        // this will be mostly same for all the states
        public override void Start(StateMachine stateMachine)
        {
            SetSpiderStateMachine(stateMachine);
        }
        

        /// <summary>
        /// Converts and store given StateMachine into SpiderStateMachine field SSM
        /// </summary>
        /// <param name="stateMachine">state machine which will be passed to be down casted to SpiderStateMachine</param>
        protected void SetSpiderStateMachine(StateMachine stateMachine)
        {
            SSM = ToSpider(stateMachine);
        }
        
        /// <summary>
        /// Down casts given StateMachine to SpiderStateMachine
        /// </summary>
        /// <param name="stateMachine">SpiderStateMachine referenced as StateMachine</param>
        /// <returns>StateMachine Down casted to SpiderStateMachine</returns>
        private static SpiderStateMachine ToSpider(StateMachine stateMachine) => (SpiderStateMachine)stateMachine;

    }
}


