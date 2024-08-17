using Godot;
using System;

public partial class InventoryHud : Control
{
	VBoxContainer Items;
	VBoxContainer Weapons;
	VBoxContainer Consumibles;
	PackedScene ButtonComponent;



	[Export] PlayerData data;
	public override void _Ready()
	{
		Items = GetNode<VBoxContainer>("MarginContainer/TabContainer/Itens");
		Weapons = GetNode<VBoxContainer>("MarginContainer/TabContainer/Armas");
		Consumibles = GetNode<VBoxContainer>("MarginContainer/TabContainer/Cura");
		ButtonComponent = GD.Load<PackedScene>("res://Components/Button/button_component.tscn");
		updateInventory();
	}

	public void  updateInventory(){
		
        foreach (Button button in GetTree().GetNodesInGroup("InventoryButtons"))
        {
            button.QueueFree();
        }

		foreach (var itemEntry in data.inventory.itemList)
        {
            var button = ButtonComponent.Instantiate<ButtonComponent>();
            button.item = itemEntry.Key;
            button.AddToGroup("InventoryButtons");

			Type type = itemEntry.Key.GetType();

            switch (type.Name)
            {
                case nameof(Consumible):
                    Consumibles.AddChild(button);
                    break;
                case nameof(WeaponItem):
                    Weapons.AddChild(button);
                    break;
                default:
                    Items.AddChild(button);
                    break;
            }
            
        }

	}

}
