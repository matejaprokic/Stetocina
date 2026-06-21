using UnityEngine;

public class SeedTask : InteractableTask
{
    public override bool CanComplete()
    {
        return Inventory.Instance.HasItem("Water")
            && Inventory.Instance.HasItem("Shovel");
    }
}
