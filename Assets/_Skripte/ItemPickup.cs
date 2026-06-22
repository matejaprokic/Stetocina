using UnityEngine;

public abstract class ItemPickup : MonoBehaviour, IInteractable
{
    public string itemName;

    public Sprite inventoryIcon;

    public Transform player;

    public float pickupDistance = 2f;


    public virtual void Interact()
    {
        float dist =
            Vector3.Distance(
                transform.position,
                player.position
            );

        if (dist > pickupDistance)
            return;

        Inventory.Instance.AddItem(itemName);

        InventoryUI.Instance.AddItem(
            itemName,
            inventoryIcon
        );

        Destroy(gameObject);
    }
}