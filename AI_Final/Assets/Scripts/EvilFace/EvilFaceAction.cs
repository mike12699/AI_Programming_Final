using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilFaceAction : GOAPAction
{
    private bool attacked = false;

    public EvilFaceAction()
    {
        addEffect("damagePlayer", true);
        cost = 100f;
    }

    public override void reset()
    {
        attacked = false;
        target = null;
    }

    public override bool isDone()
    {
        return attacked;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        target = GameObject.Find("Player");
        return target != null;
    }

    public override bool perform(GameObject agent)
    {
        EvilFace currEvilFace = agent.GetComponent<EvilFace>();
        if (currEvilFace.stamina >= (cost))
        {

            currEvilFace.animator.Play("evilfaceAttack");

            int damage = currEvilFace.strength;
            if (currEvilFace.player.isBlocking)
            {
                damage -= currEvilFace.player.defense;
            }

            currEvilFace.player.health -= damage;
            currEvilFace.stamina -= cost;

            attacked = true;
            return true;
        }

        else
        {
            return false;
        }
    }
}
