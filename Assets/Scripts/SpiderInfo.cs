using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderInfo : MonoBehaviour
{
    public float groundClearance = 0.1f;

    public bool Grounded { get; private set; }
    public SphereCollider GroundCollider { get; private set; }

    public Vector3 GroundNormal { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        Grounded = false;
        GroundCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundedLogic();
    }

    private void GroundedLogic()
    {
        // We cast ray of length groundCheckDistance down from GroundColliders centre
        // If ray hits then grounded if not then not grounded
        Vector3 origin = GroundCollider.transform.TransformPoint(GroundCollider.center);
        Vector3 direction = -GroundCollider.transform.up;
        RaycastHit hit;
        float groundCheckDistance = GroundCollider.radius + groundClearance;

        if (Physics.Raycast(origin, direction, out hit, groundCheckDistance))
        {
            //Grounded = true;
            GroundNormal = hit.normal;
            Debug.DrawLine(hit.point, hit.point + hit.normal);
            //Debug.DrawRay(origin, direction*groundCheckDistance);
        }
        else
        {
            Grounded = false;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        Grounded = true;
    }
}
