using Godot;
using System;

[GlobalClass]public partial class Item : Resource
{
    [Export] public string Name;
    [Export] public string Description;
    [Export] public Texture2D Icon;
    [Export]public bool stackable;

    public virtual void OnUse(){

    }
    
}
