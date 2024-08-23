using Godot;
using Godot.Collections;
using System;


public partial class ContainerComponent : InteractionComponent
{
	[Export] Array<eItemList> Collectables;
	[Export] public bool Collected = false;
}


