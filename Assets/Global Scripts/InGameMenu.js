#pragma strict

var hasMenuOpen : boolean = false;

function Start () {

}

function Update () {
	
	// Check for keyboard input to toggle the menu
	if(Input.GetKeyUp(KeyCode.Escape)){
		// call "ToggleMenuOpen" to toggle the menu open or closed
		ToggleMenuOpen();
	}
	
}

function ToggleMenuOpen () {
	// check if the menu is open, if so, close it
		if(hasMenuOpen == true){
			hasMenuOpen = false;
		}
		// else open the menu, since it is closed
		else{
			hasMenuOpen = true;
		}
}

function OnGUI () {
	// check if the menu is open
	if(hasMenuOpen == true){
		
		// draw the return to game button
		if(GUI.Button(new Rect(5,5,120,25),"Back To Game")){
			// toggle the menu
			ToggleMenuOpen();
		}
		
		// draw the quit button
		if(GUI.Button(new Rect(5,40,100,25),"Quit")){
			// close the application
			Application.Quit();
		}
		
		// draw the back to menu button
		if(GUI.Button(new Rect(5,70,100,25), "Menu")){
			// load the menu level
			Application.LoadLevel("Menu");
		}
	
	}
}