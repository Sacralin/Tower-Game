using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : TowerObject
{
    public CannonTower()
    {
        towerName = "Cannon";
        sprite = Resources.Load<Sprite>("Images/CannonTowerImage");
        //level1Tower = Resources.Load<GameObject>("Prefabs/CannonTowerLevel1");
        //level2Tower = Resources.Load<GameObject>("Prefabs/CannonTowerLevel2");
        //level3Tower = Resources.Load<GameObject>("Prefabs/CannonTowerLevel3");
        level1Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/cannon_tower_LVL_1_rig");
        level2Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/cannon_tower_LVL_2_rig");
        level3Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/cannon_tower_LVL_3_rig");
        level4Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/cannon_tower_LVL_4_rig");
        level1TowerCost = 100;
        level2TowerCost = 130;
        level3TowerCost = 150;
        level4TowerCost = 160;
    }
}
