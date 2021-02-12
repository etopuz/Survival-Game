using UnityEngine;
using UnityEngine.UI;
using PlayerScriptSystem;


public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField]    private Inventory inventory;
    [SerializeField]    private GameObject inventoryUI;
    [SerializeField]    private bool isInventoryOpened;
    [SerializeField]    private FPSCameraController fpsCameraController;
    [SerializeField]    private InventorySlot[] slots;


    private void Awake()
    {
        inventoryUI = transform.Find("InventoryUI").gameObject;
        slots = transform.Find("InventoryUI").GetComponentsInChildren<InventorySlot>();
        fpsCameraController = Camera.main.GetComponent<FPSCameraController>();
    }

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallBack += UpdateUI;
        isInventoryOpened = false;
        inventoryUI.SetActive(isInventoryOpened);
    }


    void Update()
    {
        CheckInventoryIsOpen();
    }


    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }

    void CheckInventoryIsOpen()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isInventoryOpened)
            {
                Cursor.lockState = CursorLockMode.None;
                isInventoryOpened = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                isInventoryOpened = false;
                
            }
            fpsCameraController.isCameraFreeze = isInventoryOpened;
            inventoryUI.SetActive(isInventoryOpened);
        }
    }

}
