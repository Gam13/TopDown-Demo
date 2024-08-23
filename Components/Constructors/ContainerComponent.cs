using Godot;
using Godot.Collections;
using System;


public partial class ContainerComponent : InteractionComponent
{
	[Export] public Array<eItemList> Collectables;
	[Export] public bool Collected = false;
}


