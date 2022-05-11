using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingArea : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Waiting", 1);
        GWorld.Instance.AddRobber(this.gameObject);
        beliefs.ModifyState("atPoliceStation", 1);

        return true;
    }
}
