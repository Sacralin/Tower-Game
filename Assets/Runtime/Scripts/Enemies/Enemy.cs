using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public GameObject selectedPrefab;
    public int timeTillNextSpawn;
    public string type;
    
    public int health;
    int footmanHealth = 25;
    int heroHealth = 50;
    int dragonHealth = 75;

    public int goldReward;
    int footmanReward = 10;
    int heroReward = 15;
    int dragonReward = 20;
    
    

    public Enemy(string prefab, int time = 1)
    {
        switch (prefab)
        {
            case "footman":
                selectedPrefab = Resources.Load<GameObject>("Minions/Mini/Prefabs/FootmanPBR");
                health = footmanHealth;
                goldReward = footmanReward;
                type = "footman";
                break;
            case "hero":
                selectedPrefab = Resources.Load<GameObject>("Minions/RPGHero/Prefabs/RPGHeroHP");
                health = heroHealth;
                goldReward = heroReward;
                type = "hero";
                break;
            case "dragon":
                selectedPrefab = Resources.Load<GameObject>("Minions/Dragons/Prefab/DragonUsurper/Red");
                health = dragonHealth;
                goldReward = dragonReward;
                type = "dragon";
                break;
            default:
                Debug.Log("Enemy type not found");
                break;
        }

        timeTillNextSpawn = time;
    }

    






}
