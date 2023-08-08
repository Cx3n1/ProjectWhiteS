using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Animations;

namespace StateMachine.SpiderStateMachine
{
    public class InAir : SpiderState
    {
        private Rigidbody _spiderBody;

        public override void Update()
        {
            CheckStateTransition();
        }

        public override void FixedUpdate()
        {
            
            // TODO: apply movement
        }

        public override void StateEntered(StateMachine stateMachine)
        {
            Debug.Log("InAir");
            base.StateEntered(stateMachine);
            SSM.SpiderBody.useGravity = true;

        }

        public override void StateExited()
        {
            base.StateExited();
            SSM.SpiderBody.useGravity = false;
        }


        private void CheckStateTransition()
        {
            if(SSM.Spider.Grounded)
                SSM.ChangeState(SSM.Land);
        }
        
        
        
    }

}