using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform targetPosition;
    public float angle;

    private void Update()
    {
        angle = Mathf.Atan2(targetPosition.position.y - transform.position.y, targetPosition.position.x - transform.position.x) * Mathf.Rad2Deg;

        // Rotate the gun
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
