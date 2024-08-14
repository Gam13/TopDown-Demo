using Godot;
using System;

public partial class Caracter : CharacterBody2D
{
    private RayCast2D interactionRaycast;
    private AnimationTree animationTree;
    public const float Speed = 100.0f;
    private Vector2 direction = Vector2.Zero;

    public override void _Ready()
    {
        animationTree = GetNode<AnimationTree>("AnimationTree");
        interactionRaycast = GetNode<RayCast2D>("InteractRaycast");
        animationTree.Set("parameters/conditions/Idle", true);
        animationTree.Set("active", true);
    }

    public override void _PhysicsProcess(double delta)
    {
        Moviment(delta);
        UpdateInteractionRaycast();
        Interaction();
        UpdateAnimations();
    }

    private void Interaction()
    {
        if (interactionRaycast.IsColliding() && Input.IsActionJustPressed("interact"))
        {
            var collider = interactionRaycast.GetCollider();
            if (collider is Interactable interactable)
            {
                interactable.Interact();
            }
            else
            {
                GD.Print($"O objeto colidido não é um Interactable: {collider.GetType()}");
            }
        }
    }

    private void UpdateInteractionRaycast()
    {
        if (direction != Vector2.Zero)
        {
            interactionRaycast.TargetPosition = direction * 13;
        }
    }

    public void Moviment(double delta)
    {
        Vector2 velocity = Velocity;

        direction = Input.GetVector("left", "right", "up", "down").Normalized();
        velocity = direction * Speed;

        Velocity = velocity;
        MoveAndSlide();
    }

    private void UpdateAnimations()
    {
        if (Velocity == Vector2.Zero)
        {
            animationTree.Set("parameters/conditions/is_moving", false);
            animationTree.Set("parameters/conditions/Idle", true);
        }
        else
        {
            animationTree.Set("parameters/conditions/Idle", false);
            animationTree.Set("parameters/conditions/is_moving", true);
        }

        if (direction != Vector2.Zero)
        {
            animationTree.Set("parameters/Idle/blend_position", direction);
            animationTree.Set("parameters/Walk/blend_position", direction);
        }
    }
}
