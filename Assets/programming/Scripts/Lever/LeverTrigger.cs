using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public GameObject[] doors;
    public Animator animator;
    public AudioSource leverPull;
    private bool doorOpen;

    // Time it takes for the doors to move (1 second in this case)
    public float doorMoveDuration = 1f;

    // Distance the doors should move (adjust as needed)
    public float doorMoveDistance;

    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            StartCoroutine(MoveDoors());
            leverPull.Play();
        }
    }

    IEnumerator MoveDoors()
    {
        if (doorOpen == false)
        {
            animator.SetBool("leverPulled", true);
            doorOpen = true;

            // Move doors up
            float initialHeight = doors[0].transform.position.y;
            float targetHeight = initialHeight + doorMoveDistance;

            for (float t = 0; t < 1f; t += Time.deltaTime / doorMoveDuration)
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].transform.Translate(Vector3.up * doorMoveDistance * Time.deltaTime / doorMoveDuration);
                }
                yield return null;
            }
        }
        else
        {
            animator.SetBool("leverPulled", false);
            doorOpen = false;

            // Move doors down
            float initialHeight = doors[0].transform.position.y;
            float targetHeight = initialHeight - doorMoveDistance;

            for (float t = 0; t < 1f; t += Time.deltaTime / doorMoveDuration)
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].transform.Translate(Vector3.down * doorMoveDistance * Time.deltaTime / doorMoveDuration);
                }
                yield return null;
            }
        }
    }
}
