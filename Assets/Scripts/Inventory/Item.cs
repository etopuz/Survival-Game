using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject prefab;
    public bool isDefaultItem = false;
    public bool isStackable;
}
