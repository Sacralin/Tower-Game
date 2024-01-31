using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{

    public GameObject archerTower;
    public GameObject cannonTower;
    public GameObject magicTower;
    private GameObject selectedTower;
    GameObject focusObj;
    bool creatingTower;

    // Start is called before the first frame update
    void Start()
    {
        creatingTower = false;
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
                if (!Physics.Raycast(ray, out hit)) { return; }
                focusObj = Instantiate(selectedTower, hit.point, selectedTower.transform.rotation);
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
                creatingTower = false;
            }
        }
    }

    public void CreateTower(string type)
    {
        creatingTower = true;
        switch (type)
        {
            case "archer":
                selectedTower = archerTower;
                break;
            case "cannon":
                selectedTower = cannonTower;
                break;
            case "magic":
                selectedTower = magicTower;
                break;
            default:
                Debug.Log("Unable to find tower shop item");
                break;
        }

    }
}
