using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInterrogated : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Police Car");
        if (target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Interrogated", 1);
        beliefs.ModifyState("isCriminal", 1);
        inventory.RemoveItem(target);
        return true;
    }
}
