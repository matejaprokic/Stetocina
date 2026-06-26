using UnityEngine;

public class EggTask : InteractableTask
{
    public override bool CanComplete()
    {
        return InventoryUI.Instance.HasSelectedItems("Srafciger", "Kukuruz");
    }
}