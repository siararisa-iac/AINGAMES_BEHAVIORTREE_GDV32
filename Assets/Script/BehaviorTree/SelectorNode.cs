using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : Node
{
    // Since selector is a composite node, it can store one or more child nodes
    private readonly List<Node> _nodes = new();

    public SelectorNode(List<Node> nodes)
    {
        _nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (Node node in _nodes)
        {
            switch (node.Evaluate())
            {
                // if a child node returns FAILURE, just continue to next child
                case NodeState.FAILURE:
                    continue;
                // if a child node return SUCCESS
                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;
            }
        }

        // This part of the  code will only run if all child evaluates as FAILURE
        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}
