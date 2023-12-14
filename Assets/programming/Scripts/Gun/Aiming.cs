using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public GameObject cam;

    void Update()
    {
        int rayLayer = LayerMask.NameToLayer("RayLayer");

        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

      
        int layerMask = 1 << rayLayer;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
        {
            transform.position = raycastHit.point;
        }
    }
}
