using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : Node
{
    // Since sequence is a composite node, it can store one or more child nodes
    private readonly List<Node> _nodes = new();

    public SequenceNode(List<Node> nodes)
    {
        _nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        bool isAnyChildRunning = false;
        foreach (Node node in _nodes)
        {
            switch (node.Evaluate())
            {
                // If a child node returns FAILURE, we exit immediately
                case NodeState.FAILURE:
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                // If a child returns SUCCESS, we go to the next child
                case NodeState.SUCCESS:
                    continue;
                case NodeState.RUNNING:
                    isAnyChildRunning = true;
                    continue;
            }
        }
        // This part of the code will only run when no child node fails
        _nodeState = isAnyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return _nodeState;
    }
}
