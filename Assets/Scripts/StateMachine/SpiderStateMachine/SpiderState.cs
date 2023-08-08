using System;
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

        protected bool Jumped = false;
        
        /// <summary>
        /// Start is called once at the creation of this state
        /// implements state machine transformation and storage to SpiderStateMachine
        /// for more accessibility
        /// </summary>
        /// <param name="stateMachine">state machine which is converted and stored as SpiderStateMachine</param>
        public override void Start(StateMachine stateMachine)
        {
            SetSpiderStateMachine(stateMachine);
        }

        /// <summary>
        /// State entered is called when state machine exits this state
        /// implements state machine transformation and storage to SpiderStateMachine
        /// for more accessibility
        /// also sets Jumped variable to false (AKA resets jump so we can jump again)
        /// </summary>
        /// <param name="stateMachine">state machine which is converted and stored as SpiderStateMachine</param>
        public override void StateEntered(StateMachine stateMachine)
        {
            SetSpiderStateMachine(stateMachine);
            Jumped = false;
        }

        /// <summary>
        /// State exited is called when state machine exits this state
        /// sets Jumped variable to false (AKA resets jump so we can jump again)
        /// </summary>
        public override void StateExited()
        {
            Jumped = false;
        }


        
        
        //++++Utility Methods++++\\

        /// <summary>
        /// Converts and store given StateMachine into SpiderStateMachine field SSM
        /// </summary>
        /// <param name="stateMachine">state machine which will be passed to be down casted to SpiderStateMachine</param>
        protected void SetSpiderStateMachine(StateMachine stateMachine)
        {
            SSM = SpiderStateMachine.ToSpider(stateMachine);
        }
        
        
        /// <summary>
        /// Used to mark down when jump is detected (jump action is pressed) in Jumped variable
        /// needed in order to not divide state transition (instead of transitioning to jump state
        /// when jump event happens we just change Jumped variable and then jump as soon as we can)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RequestJump(object sender, EventArgs e)
        {
            // we use this so that we synchronise state transition
            // with this we avoid transitioning to jump state and before
            // leaving this state we might transition to in air state so
            // that we have transition logic only in CheckTransitions
            Jumped = true;
        }
        
        


        
     
    }
}


