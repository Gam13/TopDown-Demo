using Godot;
using System;

public partial class InventoryHud : Control
{
	VBoxContainer Items;
	VBoxContainer Weapons;
	VBoxContainer Consumibles;

	[Export] PlayerData data;
	public override void _Ready()
	{
		Items = GetNode<VBoxContainer>("MarginContainer/TabContainer/Itens");
		Weapons = GetNode<VBoxContainer>("MarginContainer/TabContainer/Armas");
		Consumibles = GetNode<VBoxContainer>("MarginContainer/TabContainer/Cura");
	}

}
