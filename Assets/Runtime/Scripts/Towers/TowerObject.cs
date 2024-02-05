using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerObject
{
    public string towerName;
    public Sprite sprite;
    public GameObject level1Tower;
    public GameObject level2Tower;
    public GameObject level3Tower;
    public GameObject level4Tower;
    public int level1TowerCost;
    public int level2TowerCost;
    public int level3TowerCost;
    public int level4TowerCost;
    public int currentLevel;
    public GameObject currentTower;
    public int currentTowerCost;
    public GameObject nextLevelTower;

    public TowerObject()
    {
        SetCurrentLevel(1);
        Update();
    }

    public void Update()
    {
        switch (currentLevel)
        {
            case 1:
                currentTower = level1Tower;
                currentTowerCost = level1TowerCost;
                nextLevelTower = level2Tower;
                break; 
            case 2:
                currentTower = level2Tower;
                currentTowerCost = level2TowerCost;
                nextLevelTower = level3Tower;
                break; 
            case 3:
                currentTower = level3Tower;
                currentTowerCost = level3TowerCost;
                nextLevelTower = level4Tower;
                break;
            case 4:
                currentTower = level4Tower;
                currentTowerCost = level4TowerCost;
                nextLevelTower = null;
                break;
            default: break;
        }
    }

    public void SetCurrentLevel(int levelSet)
    {
        currentLevel = levelSet;
    }
}
