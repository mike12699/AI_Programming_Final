using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public Sequence(string n)
    {
        Name = n;
    }

    public override Status Process()
    {
        Status childStatus = children[currentChild].Process();

        if (childStatus == Status.Ongoing)
        {
            return Status.Ongoing;
        }
        if (childStatus == Status.Ongoing)
        {
            return childStatus;
        }

        currentChild++;

        if (currentChild >= children.Count)
        {
            currentChild = 0;
            return Status.Success;
        }

        return Status.Ongoing;
    }
}
