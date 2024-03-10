using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public TMP_Text goldText;
    public TMP_Text livesText;
    private int goldOverTime = 1;
    public float currentGold = 0;
    public int lives = 5;


    // Start is called before the first frame update
    void Start()
    {
        StartingLives();
    }

    // Update is called once per frame
    void Update()
    {
     

        IncrementGold();
    }

    private void IncrementGold()
    {
        currentGold += goldOverTime * Time.deltaTime;
        goldText.text = $"Gold: {(int)currentGold}";
    }

    public void StartingLives()
    {
        livesText.text = $"Lives: {lives}";
    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = $"Lives: {lives}";
    }

    
}
