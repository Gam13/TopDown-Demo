using Godot;
using System;

public partial class InteractionManager : Node
{
    public static InteractionManager instance;

    public override void _Ready()
    {
        instance = this;
    }

    public void HandleInteraction(InteractionComponent interactionComponent)
    {
        if(interactionComponent is ContainerComponent){
            GD.Print("Container");
        }
    }
}
