using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Transform shopPanelTransform;
    public Button shopItemTowerPrefab;
    ArcherTower archerTower;
    CannonTower cannonTower;
    MagicTower magicTower;
    public List<TowerObject> availableTowers;
    TowerPlacement towerPlacement;

    // Start is called before the first frame update
    void Start()
    {
        towerPlacement = FindAnyObjectByType<TowerPlacement>();
        availableTowers = new List<TowerObject>();
        archerTower = new ArcherTower();
        cannonTower = new CannonTower();
        magicTower = new MagicTower();
        availableTowers.Add(archerTower);
        availableTowers.Add(cannonTower);
        availableTowers.Add(magicTower);
        

        foreach(TowerObject tower in availableTowers)
        {
            AddTowerToShop(tower);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddTowerToShop(TowerObject type)
    {
        Button towerButton = Instantiate(shopItemTowerPrefab, shopPanelTransform);
        towerButton.name = type.towerName;
        towerButton.image.sprite = type.sprite;
    }

    public void ShopButtonPressed(string name)
    {
        foreach (TowerObject tower in availableTowers)
        {
            if (tower.towerName == name)
            {
                towerPlacement.CreateTower(tower);
            }
        }
        
    }

    public int GetTowerPrice(string name)
    {

        foreach(TowerObject tower in availableTowers)
        {
            if(tower.towerName == name)
            {
                return tower.level1TowerCost;
            }
        }
        return 0;
    }

}
