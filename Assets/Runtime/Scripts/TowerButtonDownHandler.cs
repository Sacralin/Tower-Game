using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerButtonDownHandler : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        TowerPlacement towerPlacement = FindAnyObjectByType<TowerPlacement>();
        towerPlacement.CreateTower(name);
    }
}
