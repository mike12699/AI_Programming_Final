using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAttackAction : GOAPAction
{
    private bool attacked = false;

    public FighterAttackAction()
    {
        //addPrecondition ("playerDefending", true);
        addEffect("damagePlayer", true);
        cost = 300f;
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
        Fighter currFighter = agent.GetComponent<Fighter>();

        if (target != null && target.GetComponent<PlayerMovement>().isBlocking &&
            currFighter.stamina >= (500 - cost))
        { //to-do: make scaling system instead of magic number) 
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool perform(GameObject agent)
    {
        Fighter currFighter = agent.GetComponent<Fighter>();
        currFighter.stamina -= (500 - cost);

        Animator currFighternim = GetComponentInParent<Animator>();
        //spellAnim.wrapMode = WrapMode.ClampForever; //done in inspector right now
        currFighternim.Play("FighterSpell");

        attacked = true;
        return attacked;
    }
}
