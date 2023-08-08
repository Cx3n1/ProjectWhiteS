using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace StateMachine.SpiderStateMachine
{
    
    
    public class Move : SpiderState
    {
        private readonly float _movementSpeed = 20f;
        
        public override void Update()
        {
            CheckTransitions();
        }

        public override void FixedUpdate()
        {
            HandleOrientation();
            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector3 vec = new Vector3(SSM.Brain.GetMovement().x, 0, SSM.Brain.GetMovement().y);
            //SSM.SpiderBody.transform.position -= vec * (Time.deltaTime * _movementSpeed);
            SSM.SpiderBody.velocity = -vec * _movementSpeed;
        }

        public override void StateEntered(StateMachine stateMachine)
        {
            Debug.Log("Move");
            base.StateEntered(stateMachine);
            SSM.SpiderBody.velocity = Vector3.zero;
            SSM.SpiderBody.angularVelocity = Vector3.zero;
        }

        private void CheckTransitions()
        {
            if(Jumped)
                SSM.ChangeState(SSM.Jump);
            else if (!SSM.Spider.Grounded)
                SSM.ChangeState(SSM.InAir);
            // TODO: velocity could be checked instead of movement magnitude here
            else if(SSM.Brain.GetMovement().magnitude < 0.1f) //dead zone of movement will have radius of 0.1f
                SSM.ChangeState(SSM.Idle);
        }


        private void HandleOrientation()
        {
            SSM.gameObject.transform.up = SSM.Spider.GroundNormal;
            //Vector3 look_direction = Quaternion.AngleAxis(90, SSM.gameObject.transform.right) * SSM.Spider.GroundNormal;
            //SSM.gameObject.transform.rotation = Quaternion.LookRotation(look_direction);
        }
    }
}
