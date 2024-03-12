using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    SoundPlayer soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = FindAnyObjectByType<SoundPlayer>();
        if (SceneManager.GetActiveScene().name.ToString() == "Menu")
        {
            soundPlayer.PlayStartMusic();
        }
        if (SceneManager.GetActiveScene().name.ToString() != "Menu")
        {
            soundPlayer.PlayLevelMusic();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
