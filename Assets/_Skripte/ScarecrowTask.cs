using UnityEngine;

public class ScarecrowTask : InteractableTask
{
    public override bool CanComplete()
    {
        return Inventory.Instance.HasItem("Hammer")
            && Inventory.Instance.HasItem("Key");
    }
}
