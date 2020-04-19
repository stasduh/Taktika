using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnGun : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UIControllerSingleton uiController = UIControllerSingleton.getInstance();
        
        GameController playerController = GameObject.Find("Player").GetComponent<GameController>();
        
        if (uiController.gold > playerController.cost)
        {
            GunController gunController = eventData.pointerEnter.GetComponent<GunController>();
            ++gunController.forceDamage;
            uiController.gold -= playerController.cost; 
        }     
    }
}
