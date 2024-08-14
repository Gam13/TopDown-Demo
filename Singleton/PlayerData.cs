using Godot;
using System;
using System.Dynamic;

[Serializable]
public partial class PlayerData : Node
{
    
    readonly public short MaxHp = 100;
    [Export] public int healthpoints = 50;
    [Export] public Godot.Collections.Dictionary<Item, int> Inventory = new Godot.Collections.Dictionary<Item, int>();

}
