using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 300.0f;
    
    [Export] private RayCast2D InteractionCast;
    [Export] private Control InventoryHud;
    
    private Vector2 direction;

    public override void _PhysicsProcess(double delta)
    {
        CallActions();
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 velocity = Velocity;
        direction = Input.GetVector("left", "right", "up", "down").Normalized();
        
        if (direction != Vector2.Zero)
        {
            InteractionCast.TargetPosition = direction * 25;
        }
        
        velocity = direction * Speed;
        Velocity = velocity;
        MoveAndSlide();
    }

    private void CallActions()
    {
        if (Input.IsActionJustPressed("inventory"))HandleInventory();
		if (Input.IsActionJustPressed("interact"))HandleInteract();
        
    }

    private void HandleInventory()
    {
        if (GameMaster.pauseAllowed)
        {
            if (InventoryHud.Visible)
            {
                GameMaster.paused = false;
                InventoryHud.Hide();
            }
            else
            {
                GameMaster.paused = true;
                InventoryHud.Show();
            }
        }
    }

	private void HandleInteract(){
		
	}
}
