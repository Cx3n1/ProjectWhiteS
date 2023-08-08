using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.SpiderStateMachine
{
    public class Land : SpiderState
    {

        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
        }

        public override void StateEntered(StateMachine stateMachine)
        {
            Debug.Log("Landed");
            base.StateEntered(stateMachine);
            SSM.SpiderBody.velocity = Vector3.zero;
            SSM.SpiderBody.angularVelocity = Vector3.zero;
            SSM.gameObject.transform.up = SSM.Spider.GroundNormal;
            SSM.ChangeState(SSM.Idle);
        }

    }

}
