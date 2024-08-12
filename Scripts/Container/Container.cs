using Godot;
using System;

public partial class Container : Interactable
{
    [Export] public string item;
    [Export] public int quantity;

    private AnimationTree animationTree;
    private bool inspected = false;

    // Define the signal
    [Signal]
    public delegate void ItemInteractedEventHandler(string itemName, int quantity);

    public override void _Ready()
    {
        animationTree = GetNode<AnimationTree>("AnimationTree");
        animationTree.Set("active", true);
        AddToGroup("Containers"); // Add this Container to the "containers" group
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
