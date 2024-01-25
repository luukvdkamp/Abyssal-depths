using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform targetPosition;
    public float angle;

    private void Update()
    {
        if(targetPosition.position.x > transform.position.x)
        {
            //player on right
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        else
        {
            //player on left
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
