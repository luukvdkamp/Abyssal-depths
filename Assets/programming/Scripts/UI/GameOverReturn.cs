using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverReturn : MonoBehaviour
{
    public void ButtonReturn()
    {
        SceneManager.LoadScene(0);
    }
}