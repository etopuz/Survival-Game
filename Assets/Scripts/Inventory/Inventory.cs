using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ItemInSlot
{
    public Item item;
    public int numberOfItem = 0;

    public ItemInSlot(Item item, int numberOfItem)
    {
        this.item = item;
        this.numberOfItem = numberOfItem;
    }
}

public class Inventory : MonoBehaviour
{
    #region Singleton
    private static Inventory instance;
    public static Inventory Instance {get { return instance; } }

    public void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public List<ItemInSlot> items = new List<ItemInSlot>();

    [SerializeField]    private int inventorySize = 20;
    [SerializeField]    private int stackSize = 10;

    public bool AddItem(Item item)
    {
        if (item.isDefaultItem)
            return false;

        for (int i = 0; i < items.Count; i++)
        {
            ItemInSlot itemSlot = items[i];
            bool willAddToStack =  item.isStackable &&  itemSlot.item.Equals(item) && itemSlot.numberOfItem < stackSize;

            if (willAddToStack)
            {
                itemSlot.numberOfItem++;
                if (onItemChangedCallBack != null)
                    onItemChangedCallBack.Invoke();
                return true;
            }
        }

        if(items.Count >= inventorySize)
            return false;

        AddToFirstEmptySlot(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
        return true;
    }

    private void AddToFirstEmptySlot(Item item)
    {
        ItemInSlot _itemSlot = new ItemInSlot(item, 1);
        items.Add(_itemSlot);
    }

    public void RemoveItem(ItemInSlot itemSlot)
    {
        if (itemSlot.numberOfItem == 1)
            items.Remove(itemSlot);
        else 
            itemSlot.numberOfItem -= 1;
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
