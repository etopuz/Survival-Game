using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    ItemInSlot itemInSlot;
    private int countOfObject;

    public Image icon;
    public Button removeButton;
    public Text countText;
    
    

    public void AddItem(ItemInSlot newItemInSlot)
    {
        countOfObject = newItemInSlot.numberOfItem;
        itemInSlot = newItemInSlot;
        icon.sprite = itemInSlot.item.icon;
        countText.text = countOfObject.ToString();
        SetUIActive(true);
    }

    public void ClearSlot()
    {
        itemInSlot = null;
        icon.sprite = null;
        SetUIActive(false);
    }


    public void SetUIActive(bool state)
    {
        icon.enabled = state;
        removeButton.interactable = state;
        countText.enabled = state;

    }

    public void OnRemoveButton()
    {
        Inventory.Instance.RemoveItem(itemInSlot);
    }
}

