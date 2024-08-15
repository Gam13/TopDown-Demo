using Godot;
using System;

public partial class Container : Interactable
{
    [Export] private string itemName;
    [Export] public int quantity;
    [Export] private AnimationTree animationTree;
    private bool inspected = false;
    private Item item;

    [Signal] public delegate void ItemInteractedEventHandler(Item item, int quantity);

    public override void _Ready()
    {
        animationTree = GetNode<AnimationTree>("AnimationTree");
        animationTree.Set("active", true);
        AddToGroup("Containers");


        item = ItemDatabase.GetItem(itemName);
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
