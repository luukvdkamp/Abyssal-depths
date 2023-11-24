using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform mousePosition;

    private void Update()
    {
        float angle = Mathf.Atan2(mousePosition.position.y - transform.position.y, mousePosition.position.x - transform.position.x) * Mathf.Rad2Deg;

        // Rotate the gun
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
