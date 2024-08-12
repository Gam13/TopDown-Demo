using Godot;
using System;

public partial class Container : Interactable
{
    [Export] public string item;
    [Export] public int quantity;

    [Export] private AnimationTree animationTree;
    private bool inspected = false;


    [Signal] public delegate void ItemInteractedEventHandler(string itemName, int quantity);

    public override void _Ready()
    {
        animationTree = GetNode<AnimationTree>("AnimationTree");
        animationTree.Set("active", true);
        AddToGroup("Containers");
    }

    public override void Interact()
    {
        if (!inspected)
        {
            animationTree.Set("parameters/conditions/interaction", true);
            inspected = true;
            EmitSignal(nameof(ItemInteracted), item, quantity);
        }
    }
}
