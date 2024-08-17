using Godot;
using System;

public partial class HUDControl : CanvasLayer
{
	private Control hud;
	private Control inventory;
	public override void _Ready()
	{
		hud = GetNode<Control>("Hud");
		inventory = GetNode<Control>("Inventory");
		hud.Show();
	}

	public override void _Process(double delta) {
		InventoryHandler();
	}

	public void InventoryHandler(){
		
		if(Input.IsActionJustPressed("inventory")){
			if(!inventory.Visible) inventory.Show();
			else inventory.Hide();
		}

	}
}
