using Godot;
using Managment.Scene;

public partial class Node2d : Node2D
{
	[Export] eSceneNames DebugScene;

	public void OnDebugPressed(){
		SceneManager.instance.ChangeScene(DebugScene);
	}
}