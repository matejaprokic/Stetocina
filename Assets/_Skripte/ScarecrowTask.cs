using UnityEngine;

public class ScarecrowTask : InteractableTask
{
    public override bool CanComplete()
    {
        return InventoryUI.Instance.HasSelectedItems(
        "Cigara",
        "Novine"
         );
    }
}
