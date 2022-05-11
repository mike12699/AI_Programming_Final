using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRobber : GAction
{
    GameObject resource;

    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveRobber();
        if (target == null)
            return false;
        resource = GWorld.Instance.RemovePoliceCar();
        if (resource != null)
        {
            inventory.AddItem(resource);
        }
        else
        {
            GWorld.Instance.AddRobber(target);
            target = null;
            return false;
        }

        GWorld.Instance.GetWorld().ModifyState("FreePoliceCar", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Waiting", -1);
        if (target)
        {
            target.GetComponent<GAgent>().inventory.AddItem(resource);
        }
        return true;
    }
}
