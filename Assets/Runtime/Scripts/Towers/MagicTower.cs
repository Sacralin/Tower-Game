using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTower : TowerObject
{
    public MagicTower()
    {
        towerName = "Magic";
        sprite = Resources.Load<Sprite>("Images/MagicTowerImage");
        level1Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/poison_tower_LVL_1_rig");
        level2Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/poison_tower_LVL_2_rig");
        level3Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/poison_tower_LVL_3_rig");
        level4Tower = Resources.Load<GameObject>("Towers/TowerPrefabs/poison_tower_LVL_4_rig");

        //level1Tower = Resources.Load<GameObject>("Prefabs/MagicTowerLevel1");
        //level2Tower = Resources.Load<GameObject>("Prefabs/MagicTowerLevel2");
        //level3Tower = Resources.Load<GameObject>("Prefabs/MagicTowerLevel3");
        level1TowerCost = 90;
        level2TowerCost = 110;
        level3TowerCost = 135;
        level4TowerCost = 150;
    }
}
