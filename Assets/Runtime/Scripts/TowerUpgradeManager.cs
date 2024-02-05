using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class TowerUpgradeManager : MonoBehaviour
{
    public Transform upgradePanel;
    public Button upgradeButton;
    public TMP_Text upgradeText;
    public Button cancelButton;
    private GameObject selectedTower;
    public GameObject arrow;
    private GameObject selectedTowerArrow;
    private ShopManager shopManager;
    private LevelManager levelManager;
    private TowerObject tempTowerObject;
    private int towerMaxLevel = 4;

    // Start is called before the first frame update
    void Start()
    {
        shopManager = FindAnyObjectByType<ShopManager>();
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUpgradeUI(GameObject tower)
    {
        if(selectedTower != null)
        {
            Destroy(selectedTowerArrow);
            
        }
        selectedTower = tower;
        upgradePanel.gameObject.SetActive(true);
        Vector3 arrowPosition = new Vector3(tower.transform.position.x, tower.transform.position.y + 4, tower.transform.position.z);
        selectedTowerArrow = Instantiate(arrow, arrowPosition, arrow.transform.rotation);

        tempTowerObject = new TowerObject();
        foreach (TowerObject towerObject in shopManager.availableTowers)
        {
            if (selectedTower.name == towerObject.level1Tower.name + "(Clone)")
            {
                tempTowerObject = towerObject;
                tempTowerObject.SetCurrentLevel(1);
            }
            if (selectedTower.name == towerObject.level2Tower.name + "(Clone)")
            {
                tempTowerObject = towerObject;
                tempTowerObject.SetCurrentLevel(2);
            }
            if (selectedTower.name == towerObject.level3Tower.name + "(Clone)")
            {
                tempTowerObject = towerObject;
                tempTowerObject.SetCurrentLevel(3);
            }
            if (selectedTower.name == towerObject.level4Tower.name + "(Clone)")
            {
                tempTowerObject = towerObject;
                tempTowerObject.SetCurrentLevel(4);
            }
        }
        tempTowerObject.Update();
        if(tempTowerObject.currentLevel != towerMaxLevel)
        {
            upgradeText.text = $"Upgrade\n{tempTowerObject.currentTowerCost.ToString()}";
        }
        else
        {
            upgradeText.text = "Max\nLevel!";
        }

        if (levelManager.currentGold > tempTowerObject.currentTowerCost && tempTowerObject.currentLevel != towerMaxLevel)
        {
            upgradeButton.image.color = Color.white;
        }
        else
        {
            upgradeButton.image.color = Color.red;
        }


    }

    public void UpgradeTowerButton()
    {
        if (levelManager.currentGold > tempTowerObject.currentTowerCost && tempTowerObject.currentLevel != towerMaxLevel)
        {
            if(tempTowerObject.nextLevelTower != null)
            {
                GameObject newTower = Instantiate(tempTowerObject.nextLevelTower, selectedTower.transform.position, selectedTower.transform.rotation);
                Destroy(selectedTower);
                Destroy(selectedTowerArrow);
                upgradePanel.gameObject.SetActive(false);
                levelManager.currentGold -= tempTowerObject.currentTowerCost;
            }
            
        }
    }

    public void CancelTowerButton()
    {
        upgradePanel.gameObject.SetActive(false);
        Destroy(selectedTowerArrow); 
        selectedTower = null;
    }
}
