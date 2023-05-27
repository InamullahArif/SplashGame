using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Retry_btn()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
     public void Next_level()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
         SceneManager.LoadScene(0);
    }
}
