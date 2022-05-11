using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPoliceCar : GAction
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
        GWorld.Instance.GetWorld().ModifyState("InterrogatingRobber", 1);
        GWorld.Instance.AddPoliceCar(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreePoliceCar", 1);
        return true;
    }
}
