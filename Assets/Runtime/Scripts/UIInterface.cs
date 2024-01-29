using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class UIInterface : MonoBehaviour
{
    public GameObject archerTower;
    GameObject focusObj;



    // Update is called once per frame
    void Update()
    {
        TowerStuff();

    }

    public void ArcherTowerSelected()
    {
        Debug.Log("ButtonPressed");
        //focusObj = Instantiate(archerTower, Input.mousePosition, archerTower.transform.rotation);
        //focusObj.GetComponent<Collider>().enabled = false;
    }


    public void TowerStuff()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit)) { return; }
            focusObj = Instantiate(archerTower, hit.point, archerTower.transform.rotation);
            focusObj.GetComponent<Collider>().enabled = false;
        }
        else if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit)) { return; }
            focusObj.transform.position = hit.point;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit)) { return; }
            if (hit.collider.gameObject.name == "Platform" && hit.normal.Equals(new Vector3(0, 1, 0)))
            {
                hit.collider.gameObject.name = "Occupied";
                focusObj.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, focusObj.transform.position.y, hit.collider.gameObject.transform.position.z);
            }
            else
            {
                Destroy(focusObj);
            }
            focusObj = null;
        }
    }
}