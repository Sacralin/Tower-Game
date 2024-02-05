using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : TowerObject
{
    public ArcherTower()
    {
        towerName = "Archer";
        sprite = Resources.Load<Sprite>("Images/ArcherTowerImage");
        level1Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/ballista_tower_LVL_1");
        level2Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/ballista_tower_LVL_2");
        level3Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/ballista_tower_LVL_3_rig");
        level4Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/ballista_tower_LVL_4_rig");

        //level1Tower = Resources.Load<GameObject>("Prefabs/ArcherTowerLevel1");
        //level2Tower = Resources.Load<GameObject>("Prefabs/ArcherTowerLevel2");
        //level3Tower = Resources.Load<GameObject>("Prefabs/ArcherTowerLevel3");
        level1TowerCost = 80;
        level2TowerCost = 100;
        level3TowerCost = 120;
        level4TowerCost = 150;
    }

    
}
