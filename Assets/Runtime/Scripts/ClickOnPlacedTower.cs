using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

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
        //upgradeTower.ShowUpgradeUI(gameObject);
        //RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));
        foreach (RaycastHit raycastHit in hits)
        {
            if (!raycastHit.collider.isTrigger)
            {
                if (raycastHit.collider.gameObject.CompareTag("Tower"))
                {
                    GameObject gameObject = raycastHit.collider.gameObject;
                    Debug.Log(gameObject.name);
                    upgradeTower.ShowUpgradeUI(gameObject);
                }
                
                
            }
        }
        
    }

    


}
