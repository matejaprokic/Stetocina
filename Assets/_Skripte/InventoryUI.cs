using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [System.Serializable]
    public class Slot
    {
        public Image icon;
        public Image selectionBorder;
        public Image usedOverlay;
    }

    public Slot[] slots;

    Dictionary<string, Sprite> itemSprites = new Dictionary<string, Sprite>();

    List<string> inventoryItems = new List<string>();

    HashSet<string> selectedItems = new HashSet<string>();

    HashSet<string> usedItems = new HashSet<string>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log(
                $"Slot {i} => " +
                $"icon:{slots[i].icon} " +
                $"border:{slots[i].selectionBorder} " +
                $"overlay:{slots[i].usedOverlay}"
            );
        }

        foreach (Slot slot in slots)
        {
            if (slot.selectionBorder != null)
                slot.selectionBorder.gameObject.SetActive(false);

            if (slot.usedOverlay != null)
                slot.usedOverlay.gameObject.SetActive(false);
        }
    }

    public void RegisterItemSprite(
        string itemName,
        Sprite sprite
    )
    {
        itemSprites[itemName] = sprite;
    }

    public void AddItem(
        string itemName,
        Sprite sprite
    )
    {
        if (inventoryItems.Contains(itemName))
            return;

        inventoryItems.Add(itemName);

        RegisterItemSprite(itemName, sprite);

        RefreshUI();
    }

    void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventoryItems.Count)
            {
                string item = inventoryItems[i];

                slots[i].icon.sprite = itemSprites[item];

                slots[i].icon.enabled = true;
            }
            else
            {
                slots[i].icon.enabled = false;
            }
        }
    }

    public void ToggleItem(int slotIndex)
    {
        if (slotIndex >= inventoryItems.Count)
            return;

        string item = inventoryItems[slotIndex];

        if (usedItems.Contains(item))
            return;

        if (selectedItems.Contains(item))
        {
            selectedItems.Remove(item);
            slots[slotIndex].selectionBorder.gameObject.SetActive(false);
        }
        else
        {
            selectedItems.Add(item);
            slots[slotIndex].selectionBorder.gameObject.SetActive(true);
        }

    }

    public bool HasSelectedItems(
        params string[] requiredItems
    )
    {
        foreach (string item in requiredItems)
        {
            if (!selectedItems.Contains(item))
                return false;
        }

        return true;
    }

    public void ClearSelection()
    {
        selectedItems.Clear();

        foreach (Slot slot in slots)
        {
            if (slot.selectionBorder != null)
                slot.selectionBorder.gameObject.SetActive(false);
        }
    }

    public void MarkItemAsUsed(string itemName)
    {
        usedItems.Add(itemName);

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i] == itemName)
            {
                slots[i].selectionBorder.gameObject.SetActive(false);

                if (slots[i].usedOverlay != null)
                    slots[i].usedOverlay.gameObject.SetActive(true);
            }
        }
    }
}
