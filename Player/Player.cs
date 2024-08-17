using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]public PlayerData data;
    [Export]private RayCast2D interaction;
	private Vector2 direction = Vector2.Zero;
	public const float Speed = 300.0f;

    public override void _Ready() {
        
    }
	public override void _PhysicsProcess(double delta)
	{
		Moviment();
        UpdateInteractionRaycast();
	}

	public void Moviment()
    {
        Vector2 velocity = Velocity;

        direction = Input.GetVector("left", "right", "up", "down").Normalized();
        velocity = direction * Speed;

        Velocity = velocity;
        MoveAndSlide();
    }

    private void UpdateInteractionRaycast() 
    {
        if (direction != Vector2.Zero)
        {
            interaction.TargetPosition = direction * 25;
        }
    }


}
