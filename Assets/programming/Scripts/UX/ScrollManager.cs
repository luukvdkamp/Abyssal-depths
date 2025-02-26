using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public Canvas controlsCanvas;
    public float rangeBeforeCanvas;
    public Transform playerPosition;

    void Update()
    {
        if (Vector3.Distance(transform.position, playerPosition.position) < rangeBeforeCanvas)
            controlsCanvas.gameObject.SetActive(true);

        else
            controlsCanvas.gameObject.SetActive(false);
    }
}
