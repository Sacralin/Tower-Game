using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Transform shopPanelTransform;
    public Button shopItemTowerPrefab;
    public Sprite archerTowerImage;
    public Sprite cannonTowerImage;
    public Sprite magicTowerImage;

    // Start is called before the first frame update
    void Start()
    {
        AddTowerToShop("archer");
        AddTowerToShop("cannon");
        AddTowerToShop("magic");
    }
    // Update is called once per frame
    void Update()
    {
        //need to depict tower availablity based on "gold"
        //to do this change the colour of the tower to red maybe when its not available?
    }

    private void AddTowerToShop(string type)
    {
        Button towerButton = Instantiate(shopItemTowerPrefab, shopPanelTransform);
        towerButton.name = type;
        switch (type)
        {
            case "archer":
                towerButton.image.sprite = archerTowerImage;
                break;
            case "cannon":
                towerButton.image.sprite = cannonTowerImage;
                break;
            case "magic":
                towerButton.image.sprite = magicTowerImage;
                break;
            default:
                Debug.Log("Unable to find tower shop item");
                break;
        }
    }

}
