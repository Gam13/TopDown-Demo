using Godot;
using System;

public partial class Camera : Camera2D
{
	CharacterBody2D caracter;
	[Export] private bool isFollowing = true;
	public override void _Ready()
	{
		caracter = GetNode<CharacterBody2D>("../Caracter");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (isFollowing)
		{
			followCam();
		}

	}

	void followCam()
	{
		Position = caracter.Position;
	}
}

