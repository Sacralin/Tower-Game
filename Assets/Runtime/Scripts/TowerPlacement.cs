using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private GameObject selectedTower;
    private GameObject focusObj;
    private bool creatingTower;
    private LevelManager levelManager;
    private int towerPrice;

    // Start is called before the first frame update
    void Start()
    {
        creatingTower = false;
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (creatingTower)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!RaycastWithoutTriggers(ray, out hit)) { return; }
                focusObj = Instantiate(selectedTower, hit.point, selectedTower.transform.rotation);
                //focusObj.GetComponent<Collider>().enabled = false;
                SetCollidersEnabled(false);
            }
            else if (Input.GetMouseButton(0) && focusObj != null)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!RaycastWithoutTriggers(ray, out hit)) { return; }
                focusObj.transform.position = hit.point;

            }
            else if (Input.GetMouseButtonUp(0) && focusObj != null)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!RaycastWithoutTriggers(ray, out hit)) { return; }
                if (hit.collider.gameObject.name == "Platform" && hit.normal.Equals(new Vector3(0, 1, 0)))
                {
                    hit.collider.gameObject.name = "Occupied";
                    focusObj.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, focusObj.transform.position.y, hit.collider.gameObject.transform.position.z);
                    //focusObj.GetComponent<Collider>().enabled = true;
                    SetCollidersEnabled(true);
                    levelManager.currentGold -= towerPrice; 
                }
                else
                {
                    Destroy(focusObj);
                    
                }
                focusObj = null;
                creatingTower = false;
            }
        }
    }

    public void CreateTower(TowerObject tower)
    {
        towerPrice = tower.level1TowerCost;
        selectedTower = tower.level1Tower;
        if(towerPrice <= levelManager.currentGold)
        {
            creatingTower = true;
        }
        
    }


    private void SetCollidersEnabled(bool enabled)
    {
        Collider[] colliders = focusObj.GetComponents<Collider>();
        foreach (Collider collider in colliders) { collider.enabled = enabled; }
    }

    private bool RaycastWithoutTriggers(Ray ray, out RaycastHit hit)
    {
        RaycastHit[] hits = Physics.RaycastAll(ray);
        Array.Sort(hits, (x,y) => x.distance.CompareTo(y.distance));
        foreach(RaycastHit raycastHit in hits)
        {
            if (!raycastHit.collider.isTrigger)
            {
                hit = raycastHit;
                return true;
            }
        }
        hit = new RaycastHit();
        return false;
    }

}
