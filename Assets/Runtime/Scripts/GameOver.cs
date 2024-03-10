using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TMP_Text infoText;
    public Button continueButton;
    Spawner spawner;
    LevelManager levelManager;
    List<Enemy> enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindAnyObjectByType<Spawner>();
        levelManager = GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndConditionCheck(Enemy destroyedEnemy)
    {
        if(!enemies.Contains(destroyedEnemy))
        {
            enemies.Add(destroyedEnemy);
        }
        if (levelManager.lives <= 0)
        {
            Lose();
        }
        if (enemies.Count == spawner.totalNumberOfEnemies) 
        {
            Win();
        }

    }

    public void Lose()
    {
        Debug.Log("You lose");
        infoText.text = "You Lose!";
        infoText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
    }

    public void Win()
    {
        
        Debug.Log("You win");
        infoText.text = "You Win!";
        infoText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
    }
}
