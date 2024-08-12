using Godot;
using System;

public partial class Container : Interactable
{

	[Export] public string item;
	[Export] public int quantity;
	[Signal] public delegate void onInteractEventHandler(string item, int quantity);

	private AnimationTree animationTree;
	private bool inspected = false;

	public override void _Ready()
	{
		animationTree = GetNode<AnimationTree>("AnimationTree");
		animationTree.Set("active", true);
	}


	public override void Interact()
	{
		if (!inspected)
		{
			EmitSignal("onInteractEventHandler", item, quantity);

			animationTree.Set("parameters/conditions/interaction", true);
			inspected = true;
			GD.Print("Cheguei 3");
		}
	}
}
