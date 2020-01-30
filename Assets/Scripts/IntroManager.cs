using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Start"))
        {
            LoadGame();
        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
