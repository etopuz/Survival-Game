using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    private int id;
    private string title;
    private string description;
    private Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public int Id { get => id;}
    public string Title { get => title;}
    public string Description { get => description;}
    public Sprite Icon { get => icon;}

    public Item(int id, string title, string description, Sprite icon, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Assets/UI/Inventory/Sprites/Inventory_icons" + title);
        this.stats = stats;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = item.icon;
        this.stats = item.stats;
    }

}
