using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopCamera : MonoBehaviour
{
    public GameObject cam;

    public Transform camShopPosition;
    public Transform camLevelPosition;

    public float transitionSpeed;

    private Transform targetPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            targetPosition = camShopPosition;
            StartCoroutine(MoveCameraSmoothly());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetPosition = camLevelPosition;
            StartCoroutine(MoveCameraSmoothly());
        }
        
    }

    private IEnumerator MoveCameraSmoothly()
    {
        while (Vector3.Distance(cam.transform.position, targetPosition.position) > 0.01f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition.position, transitionSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure that the camera reaches the exact target position
        cam.transform.position = targetPosition.position;
    }
}
