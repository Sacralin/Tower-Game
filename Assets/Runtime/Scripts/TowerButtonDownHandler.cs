using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButtonDownHandler : MonoBehaviour, IPointerDownHandler
{
    private Image buttonImage;
    private LevelManager levelManager;
    private ShopManager shopManager;
    public TMP_Text text;
    public void OnPointerDown(PointerEventData eventData)
    {
        shopManager.ShopButtonPressed(name);
    }

    void Start()
    {
        buttonImage = GetComponent<Image>(); // used to change the colour of the image
        shopManager = FindAnyObjectByType<ShopManager>();
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    void Update()
    {
        int towerPrice = shopManager.GetTowerPrice(name);
        text.text = towerPrice.ToString();
        if(levelManager.currentGold > towerPrice)
        {
            buttonImage.color = Color.white;
        }
        else
        {
            buttonImage.color = Color.red;
        }
    }

}
