using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeModel : MonoBehaviour
{
    public GameObject knifeObject;
    void Update()
    {
        transform.localRotation = knifeObject.transform.rotation * Quaternion.Euler(0, 0, 180);
        transform.position = knifeObject.transform.position;
    }
}
