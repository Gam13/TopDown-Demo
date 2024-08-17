using Godot;
using System;

public abstract partial  class  WeaponItem : Item
{
    [Export] int level;
    [Export] int damage;
    [Export] int speed;

}