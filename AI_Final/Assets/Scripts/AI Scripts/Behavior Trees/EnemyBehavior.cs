using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    BehaviorTree tree;
    public GameObject clock;
    public GameObject shelf;
    public GameObject ball;
    public GameObject vehicle;
    //public GameObject door1;
    //public GameObject door2;
    public GameObject gameoverPanel;
    NavMeshAgent agent;

    public enum ActionState { Idle, Working };
    ActionState state = ActionState.Idle;

    Node.Status treeStatus = Node.Status.Ongoing;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        tree = new BehaviorTree();
        Sequence gather = new Sequence("Gather Something");
        Leaf goToClock = new Leaf("Go To Clock", GoToClock);
        Leaf goToShelf = new Leaf("Go To Shelf", GoToShelf);
        Leaf goToBall = new Leaf("Go To Ball", GoToBall);
        Leaf goToVehicle = new Leaf("Go To Vehicle", GoToVehicle);
        //Leaf goToDoor1 = new Leaf("Go To Door 1", GoToDoor1);
        //Leaf goToDoor2 = new Leaf("Go To Door 2", GoToDoor2);
        //Selector opendoor = new Selector("Open Door");

        //opendoor.AddChild(goToDoor1);
        //opendoor.AddChild(goToDoor2);

        //gather.AddChild(opendoor);
        gather.AddChild(goToClock);
        gather.AddChild(goToShelf);
        gather.AddChild(goToBall);
        gather.AddChild(goToVehicle);
        tree.AddChild(gather);

        tree.PrintTree();
    }

    public Node.Status GoToClock()
    {
        Node.Status s = GoToLocation(clock.transform.position);
        if (s == Node.Status.Success)
        {
            clock.SetActive(false);
            //clock.transform.parent = this.gameObject.transform;
        }
        return s;
    }

    public Node.Status GoToShelf()
    {
        Node.Status s = GoToLocation(shelf.transform.position);
        if (s == Node.Status.Success)
        {
            shelf.SetActive(false);
            //shelf.transform.parent = this.gameObject.transform;
        }
        return s;
    }

    public Node.Status GoToBall()
    {
        Node.Status s = GoToLocation(ball.transform.position);
        if (s == Node.Status.Success)
        {
            ball.SetActive(false);
            //ball.transform.parent = this.gameObject.transform;
        }
        return s;
    }

    //public Node.Status GoToDoor1()
    //{
    //    return GoToDoor(door1);
    //}

    //public Node.Status GoToDoor2()
    //{
    //    return GoToDoor(door2);
    //}

    public Node.Status GoToVehicle()
    {
        Node.Status s = GoToLocation(vehicle.transform.position);
        if (s == Node.Status.Success)
        {
            gameoverPanel.SetActive(true);
        }
        return s;
    }

    //public Node.Status GoToDoor(GameObject door)
    //{
    //    Node.Status s = GoToLocation(door.transform.position);
    //    if (s == Node.Status.Success)
    //    {
    //        if (!door.GetComponent<Lock>().isLocked)
    //        {
    //            door.SetActive(false);
    //            return Node.Status.Success;
    //        }
    //        return Node.Status.Failure;
    //    }
    //    else
    //    {
    //        return s;
    //    }
    //}

    public Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(destination, this.transform.position);
        if (state == ActionState.Idle)
        {
            agent.SetDestination(destination);
            state = ActionState.Working;
        }
        else if (Vector3.Distance(agent.pathEndPosition, destination) >= 2)
        {
            state = ActionState.Idle;
            return Node.Status.Failure;
        }
        else if (distanceToTarget < 2)
        {
            state = ActionState.Idle;
            return Node.Status.Success;
        }
        return Node.Status.Ongoing;
    }

    private void Update()
    {
        if (treeStatus != Node.Status.Success)
        {
            treeStatus = tree.Process();
        }
    }
}
