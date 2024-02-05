using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnPlacedTower : MonoBehaviour
{
    TowerUpgradeManager upgradeTower;

    // Start is called before the first frame update
    void Start()
    {
        upgradeTower = FindAnyObjectByType<TowerUpgradeManager>();
    }

    private void OnMouseDown()
    {
        upgradeTower.ShowUpgradeUI(gameObject);
    }

    
}
