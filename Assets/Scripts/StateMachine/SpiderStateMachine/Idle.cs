using System;
using UnityEngine;

namespace StateMachine.SpiderStateMachine
{
    public class Idle : SpiderState
    {

        private SpiderStateMachine _ssm;

        private Vector2 _movement;

        public override void Update()
        {
            CheckTransitions();
        }

        public override void FixedUpdate()
        {
            SSM.gameObject.transform.up = SSM.Spider.GroundNormal;
            //may be occasionally play idle animation?
        }

        public override void StateEntered(StateMachine stateMachine)
        {
            Debug.Log("Idle");
            base.StateEntered(stateMachine);
            SSM.Brain.Jump += RequestJump;
            SSM.SpiderBody.velocity = Vector3.zero;
            SSM.SpiderBody.angularVelocity = Vector3.zero;
        }

        public override void StateExited()
        {
            base.StateExited();
            SSM.Brain.Jump -= RequestJump;
        }
        
        private void CheckTransitions()
        {
            if(Jumped)
                SSM.ChangeState(SSM.Jump);
            else if (!SSM.Spider.Grounded)
                SSM.ChangeState(SSM.InAir);
            else if(SSM.Brain.GetMovement().magnitude > 0.1f) //dead zone of movement will have radius of 0.1f
                SSM.ChangeState(SSM.Move);
        }
        
    }
}
