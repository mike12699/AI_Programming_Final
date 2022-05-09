using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum Status
    {
        Success, Failure, Ongoing
    };
    public Status status;
    public List<Node> children = new List<Node>();
    public int currentChild = 0;
    public string Name;

    public Node()
    {

    }

    public Node(string n)
    {
        Name = n;
    }

    public virtual Status Process()
    {
        return children[currentChild].Process();
    }

    public void AddChild(Node n)
    {
        children.Add(n);
    }
}
