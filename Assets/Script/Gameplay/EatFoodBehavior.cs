using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodBehavior : MonoBehaviour
{
    // Get references of other scripts
    private PlayerHunger _hunger;
    private Awareness _awareness;
    private Inventory _inventory;

    // Declare all the nodes of the Behavior Tree
    private SequenceNode _rootNode;
    private ActionNode _anCheckHunger;
    private SelectorNode _selInventoryCheck;
    private ActionNode _anCheckMeat;
    private ActionNode _anCheckVegetable;
    private ActionNode _anCheckFruit;
    private Inverter _inCheckEnemyProximity;
    private ActionNode _anCheckEnemyProximity;
    private ActionNode _anEatFood;


    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _awareness = GetComponent<Awareness>();
        _hunger = GetComponent<PlayerHunger>();
    }

    private void Start()
    {
        // Build the actual behavior tree

        _anEatFood = new ActionNode(EatFood);
        _anCheckEnemyProximity = new ActionNode(IsEnemyNear);
        _anCheckFruit = new ActionNode(CheckForFruit);
        _anCheckMeat = new ActionNode(CheckForMeat);
        _anCheckVegetable = new ActionNode(CheckForVegetable);
        _anCheckHunger = new ActionNode(IsHungry);

        _inCheckEnemyProximity = new Inverter(_anCheckEnemyProximity);

        List<Node> selectorChildren = new()
        {
            _anCheckMeat,
            _anCheckVegetable,
            _anCheckFruit,
        };
        _selInventoryCheck = new SelectorNode(selectorChildren);

        List<Node> rootChildren = new()
        {
            _anCheckHunger,
            _selInventoryCheck,
            _inCheckEnemyProximity,
            _anEatFood
        };
        _rootNode = new SequenceNode(rootChildren);
    }

    private void Update()
    {
        _rootNode.Evaluate();
    }

    private NodeState EatFood()
    {
        _hunger.IncreaseHunger(50);
        return NodeState.SUCCESS;
    }

    private NodeState IsEnemyNear()
    {
        return _awareness.IsNearEnemy() ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    private NodeState CheckForMeat()
    {
        return _inventory.CheckInventory("Meat");
    }
    private NodeState CheckForFruit()
    {
        return _inventory.CheckInventory("Fruit");
    }
    private NodeState CheckForVegetable()
    {
        return _inventory.CheckInventory("Vegetable");
    }

    private NodeState IsHungry()
    {
        return _hunger.IsHungry ? NodeState.SUCCESS : NodeState.FAILURE;
    }

}
