using Godot;
using System;


public partial class InteractionComponent : Node
{	
	[Signal] public delegate void InteractEventHandler();

	public override void _Ready()
	{
		AddToGroup("Interactable");
	}

}


