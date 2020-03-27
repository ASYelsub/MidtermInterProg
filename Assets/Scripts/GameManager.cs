using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame() //I don't know if UI buttons & functions were covered in class.
    {
        print("hello");
        SceneManager.LoadScene("SampleScene");
    }
}
