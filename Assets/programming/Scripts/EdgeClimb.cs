using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeClimb : MonoBehaviour
{
    public float climbResetTime;
    private float climbResetCounter;

    public float edgeClimbForce;
    public bool isEdgeClimbing;

    public PlayerAnimations playerAnimations;
    void Update()
    {
        if(isEdgeClimbing && climbResetCounter > climbResetTime)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * edgeClimbForce * Time.deltaTime);
            isEdgeClimbing = false;
            playerAnimations.edgeClimbing = true;
        }

        else
        {
            isEdgeClimbing = false;
            playerAnimations.edgeClimbing = false;
        }
    }
}
