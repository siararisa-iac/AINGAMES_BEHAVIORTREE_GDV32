using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    // Getter for readability outside of the class
    public NodeState NodeState => _nodeState;
    protected NodeState _nodeState;

    // Define a delegate that will return a type of NodeState and accepts 0 parameters
    public delegate NodeState NodeReturnDelegate();

    // Default Constructor
    public Node() { }

    // Function that every derived class must implement for return the node state
    // It will contain the logic whether the node returns success, failure, or running
    public abstract NodeState Evaluate();
}
