using UnityEngine;

public class EggTask : InteractableTask
{
    public override bool CanComplete()
    {
        return Inventory.Instance.HasItem("Key")
            && Inventory.Instance.HasItem("Hammer");
    }
}