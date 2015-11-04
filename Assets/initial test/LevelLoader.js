#pragma strict

public var levelName : String = "Menu";

public function LoadLevel () {
	// load the level by name
	Application.LoadLevel(levelName);
}