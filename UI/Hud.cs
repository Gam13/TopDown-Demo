using Godot;
using System;

public partial class Hud : Control
{
	ProgressBar HPbar;
	[Export] PlayerData playerData;
	public override void _Ready() {
		HPbar = GetNode<ProgressBar>("MarginContainer/VBoxContainer/HPBar");
	}
	public override void _Process(double delta)
	{
		HPbar.MaxValue = playerData.MAX_LIFE;
		HPbar.Value = playerData.life;
	}
}
