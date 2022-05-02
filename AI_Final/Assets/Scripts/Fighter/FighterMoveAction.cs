using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMoveAction : GOAPAction
{
    private bool moved = false;
    private float dashSpeed;
    private Vector3 dashTarget;
    private bool isDashing = false;

    public FighterMoveAction()
    {
        //addPrecondition ("playerAttacking", true);
        //addPrecondition("canAct", true);
        addEffect("stayAlive", true);
        cost = 400f;
        dashSpeed = .1f;
    }

    void Update()
    {

        Transform curr = GetComponentInParent<Transform>();
        if (isDashing)
        {
            curr.position = Vector3.MoveTowards(curr.position, dashTarget, dashSpeed);
        }
        if (curr.position == dashTarget)
        {
            isDashing = false;
        }
    }

    public override void reset()
    {
        moved = false;
        target = null;
    }

    public override bool isDone()
    {
        return moved;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        target = GameObject.Find("Player");
        Fighter currFighter = agent.GetComponent<Fighter>();
        if (target != null && currFighter.stamina >= (500 - cost)
            && !target.GetComponent<PlayerMovement>().isBlocking)
        {
            return true;
        }
        return false;
    }

    public override bool perform(GameObject agent)
    {
        Fighter currFighter = agent.GetComponent<Fighter>();
        if (currFighter.stamina >= (500 - cost) && !isDashing)
        {

            currFighter.stamina -= (500 - cost); //to-do: magic number

            Animator currFighternim = GetComponentInParent<Animator>();
            currFighternim.Play("FighterEvade");

            currFighter.setSpeed(dashSpeed);
            Vector2 point = Random.insideUnitCircle * 5;
            Vector3 targetPoint = new Vector3(target.transform.position.x + point.x,
                target.transform.position.y + point.y,
                target.transform.position.z);

            isDashing = true;
            dashTarget = targetPoint;

            currFighternim.SetTrigger("dashComplete");

            moved = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
