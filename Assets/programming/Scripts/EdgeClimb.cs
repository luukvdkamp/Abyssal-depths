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
    public MovementPlayer movementPlayer;
    public bool playEdgeClimbAnimation;
    public float edgeClimbAnimationTime;
    private float animationCounter;
    void Update()
    {
        climbResetCounter += Time.deltaTime;
        if(isEdgeClimbing && climbResetCounter > climbResetTime)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            print("edgeClimbing");
            isEdgeClimbing = false;
            playerAnimations.edgeClimbing = true;
            climbResetCounter = 0;
            playEdgeClimbAnimation = true;
        }

        else
        {
            isEdgeClimbing = false;
        }

        //animation
        if(playEdgeClimbAnimation)
        {
            animationCounter += Time.deltaTime;
            movementPlayer.enabled = false;
            if (animationCounter > edgeClimbAnimationTime)
            {
                movementPlayer.gravity = 0;
                transform.position += new Vector3(0, 2, 0);
                GetComponent<Rigidbody>().isKinematic = false;
                movementPlayer.enabled = true;
                animationCounter = 0;
                playerAnimations.edgeClimbing = false;
                playEdgeClimbAnimation = false;
                gameObject.isStatic = false;
            }
        }
    }
}
