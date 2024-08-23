using Godot;
using System;

public class PlayerData {

	
	public int MAX_HP = 100;
	public int current_HP = 100;


	public Godot.Collections.Dictionary<ItemType, int> inventory = new();

	//Gerênciamento de  posicionamento
	public string savedScene = default;
	Vector2 position;

}
