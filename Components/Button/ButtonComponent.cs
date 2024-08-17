using Godot;
using System;

public partial class ButtonComponent : Button
{
	[Export] public Item item;
	[Export] public PlayerData data;
	private Label amount;
	public override void _Ready()
	{
		Text = item.Name;
		Icon = item.Icon;
		amount = GetNode<Label>("amount");

		if (item.stackable)
		{
			amount.Show();
		}

		int itemAmount = data.inventory.GetAmount(item);
		amount.Text = $"x {itemAmount.ToString()}";
	}


}
