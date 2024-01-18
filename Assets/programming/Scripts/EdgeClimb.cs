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
    public bool playEdgeClimbAnimation;
    public float edgeClimbAnimationTime;
    private float animationCounter;

    public int teleportDirection;
    void Update()
    {
        climbResetCounter += Time.deltaTime;
        if(isEdgeClimbing && climbResetCounter > climbResetTime)
        {
            gameObject.isStatic = true;
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
            if(animationCounter > edgeClimbAnimationTime)
            {
                animationCounter = 0;
                playerAnimations.edgeClimbing = false;
                playEdgeClimbAnimation = false;
                gameObject.isStatic = false;
                transform.position += new Vector3(teleportDirection, 1, 0);
            }
        }
    }
}
