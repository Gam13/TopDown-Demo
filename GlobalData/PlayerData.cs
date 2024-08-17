using Godot;
using System;

[GlobalClass]public partial class PlayerData : Resource
{
        [Export] public int MAX_LIFE = 100;
        [Export] public int life;
        [Export] public Item meleeWeapon;
        [Export] public Item rangedWeapon;
        [Export] public Inventory inventory = new  Inventory();


}
