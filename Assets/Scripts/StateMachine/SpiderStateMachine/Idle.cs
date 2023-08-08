using System;
using UnityEngine;

namespace StateMachine.SpiderStateMachine
{
    public class Idle : SpiderState
    {
        private SpiderBrain _brain;

        private SpiderStateMachine _ssm;

        private Vector2 _movement;

        public override void Update()
        {
            CheckTransitions();
        }

        public override void FixedUpdate()
        {
        }

        public override void StateEntered(StateMachine stateMachine)
        {
            SetSpiderStateMachine(stateMachine);
            _brain = SSM.Brain;
            _brain.Jump += TransitionToJump;
        }

        public override void StateExited()
        {
            _brain.Jump -= TransitionToJump;
        }
        
        private void TransitionToJump(object sender, EventArgs e)
        {
            SSM.ChangeState(SSM.Jump);
        }

        private void CheckTransitions()
        {
            //if spider(GameObject) is not grounded:
            //  transition to air
            if(_brain.GetMovement().magnitude > 0.1f) //dead zone of movement will have radius of 0.1f
                SSM.ChangeState(SSM.Move);
            
        }
        
    }
}
