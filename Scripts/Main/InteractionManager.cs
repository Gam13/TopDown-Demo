using Godot;
using System;

public partial class InteractionManager : Node
{
    public static InteractionManager instance;

    public override void _Ready()
    {
        instance = this;
    }

    public InteractionComponent FindInteractionComponentInChildren(Node parent)
    {
        // Verifica se o node atual é um InteractionComponent
        if (parent is InteractionComponent interactionComponent)
        {
            return interactionComponent;
        }

        // Busca recursivamente nos filhos
        foreach (Node child in parent.GetChildren())
        {
            var found = FindInteractionComponentInChildren(child);
            if (found != null)
            {
                return found;
            }
        }

        // Nenhum InteractionComponent encontrado
        return null;
    }
    public void HandleInteraction(InteractionComponent interactionComponent)
    {
        if(interactionComponent is ContainerComponent){
            GD.Print("Container");
        }
    }
}
