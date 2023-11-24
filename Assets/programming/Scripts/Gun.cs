using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform mousePosition;

    private void Update()
    {
        transform.LookAt(mousePosition);
    }
}
