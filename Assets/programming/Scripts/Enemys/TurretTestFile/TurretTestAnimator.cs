using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTestAnimator : MonoBehaviour
{
    public Animator turretAnimatorTest;
    public TurretShooting turretCodeTest;

    // offset time for aim animation really stops
    public float aimAnimationOffset;
    private float aimOffsetCounter;

    public Transform playerPosition;

    public enum AnimationState
    {
        Idle,
        Aiming,
        Damaged
    }

    public AnimationState turretState;


    private void Start()
    {
        turretState = AnimationState.Idle;
    }

    void Update()
    {
        switch (turretState)
        {
            case AnimationState.Idle:

                if (turretCodeTest.aiming)
                {
                    turretState = AnimationState.Aiming;
                    turretAnimatorTest.SetBool("Aiming", true);
                }

                break;

            case AnimationState.Aiming:

                if (turretCodeTest.aiming == false)
                {
                    aimOffsetCounter += Time.deltaTime;

                    if(aimOffsetCounter > aimAnimationOffset)
                    {
                        turretState = AnimationState.Idle;
                        turretAnimatorTest.SetBool("Aiming", false);
                        aimOffsetCounter = 0;
                    }
                }



                float frameTarget = 0f;

                // links
                if (playerPosition.position.x < transform.position.x)
                {
                    // omhoog
                    if (playerPosition.position.y > transform.position.y)
                        frameTarget = 50f;
                    // omlaag
                    else
                        frameTarget = 25f;
                }
                // rechts
                else
                {
                    // omhoog
                    if (playerPosition.position.y > transform.position.y)
                        frameTarget = 75f;
                    // omlaag
                    else
                        frameTarget = 100f;
                }

                // zet frame over naar normalizedTime
                float normalizedTime = frameTarget / 100f;

                // smooth overgang
                turretAnimatorTest.CrossFade("Aiming", 0.1f, 0, normalizedTime);


                break;

            case AnimationState.Damaged:

                // check if animation done
                if (turretAnimatorTest.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && turretAnimatorTest.GetCurrentAnimatorStateInfo(0).IsName("Damaged"))
                {
                    print("working");
                    turretAnimatorTest.SetBool("Damaged", false);
                    turretState = AnimationState.Idle;
                }


                break;
        }

        // check for damaged animation
        if (turretCodeTest.beginHealth != turretCodeTest.turretHealth.health)
        {
            turretState = AnimationState.Damaged;
            turretAnimatorTest.SetBool("Damaged", true);
            turretCodeTest.beginHealth = turretCodeTest.turretHealth.health;
        }
    }
}
