using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Item item;

    public void CheckCollect(RaycastHit hit, KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            bool wasPickedUp = Inventory.Instance.AddItem(item);

            if (wasPickedUp)
            {
                Destroy(hit.transform.gameObject);
            }
            
        }
    }
}
