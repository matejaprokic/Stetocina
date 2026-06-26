using UnityEngine;

public class SeedTask : InteractableTask
{
    public override bool CanComplete()
    {
        return InventoryUI.Instance.HasSelectedItems("Lopata","Vreca");
    }
}
