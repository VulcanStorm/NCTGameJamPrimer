using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	//heath bar variables
	public float currHealth = 100;
	public float maxHealth = 100;
	public Vector2 maxHealthBarSizePx = new Vector2(100,10);
	public Vector2 halfHealthBarSizePx;
	public float scaledHealthBarWidth = 0;

	// gui positioning variables
	public Texture2D healthBarTex;
	public Texture2D healthLostBarTex;
	public bool showHealthBar = false;
	public uint cameraViewAngle = 60;
	public float angleToCam = 0;
	public Vector3 dirToCamera = Vector3.zero;
	public Rect healthBarRect;
	public Rect healthLostBarRect;
	public Vector3 screenPos;
	public Transform healthBarTransform = null;
	public Transform mainCamTransform = null;
	// Use this for initialization
	void Start () {
		mainCamTransform = Camera.main.transform;
		halfHealthBarSizePx = maxHealthBarSizePx / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// get the screen position
		GetGUIScreenPos ();

		// do we show the health bar?
		if (showHealthBar == true) {
			// calculate the GUI rect to display

			// compute the desired width of the texture
			// max size * (fraction of health left)
			scaledHealthBarWidth = maxHealthBarSizePx.x * (currHealth/maxHealth);

			// set the rect x and y positions
			healthBarRect.x = screenPos.x - scaledHealthBarWidth/2;
			healthBarRect.y = Screen.height - screenPos.y - halfHealthBarSizePx.y;
			// set the width and height
			healthBarRect.width = (int)scaledHealthBarWidth;
			healthBarRect.height = maxHealthBarSizePx.y;

			// set the health lost rect
			healthLostBarRect = healthBarRect;
			healthLostBarRect.x = screenPos.x - halfHealthBarSizePx.x;
			healthLostBarRect.width = maxHealthBarSizePx.x;

			// calculate gui asect ratio
			float texAspectRatio = healthBarRect.width/healthBarRect.height;
			float healthLostAspectRatio = healthLostBarRect.width/healthLostBarRect.height;
			// draw the textures
			// health lost first
			GUI.DrawTexture(healthLostBarRect,healthLostBarTex, ScaleMode.ScaleToFit,true,healthLostAspectRatio);
			// current health on top
			GUI.DrawTexture(healthBarRect,healthBarTex, ScaleMode.ScaleToFit,true,texAspectRatio);

		}
	}

	void GetGUIScreenPos () {

		// get direction from camera
		dirToCamera = healthBarTransform.position - mainCamTransform.position;
		// compute angle from camera
		angleToCam = Vector3.Angle (mainCamTransform.forward, dirToCamera);

		// check angle to camera
		if (angleToCam < cameraViewAngle) {
			// we are on screen, show the gui box
			showHealthBar = true;
			// also calculate the position rect
			screenPos = Camera.main.WorldToScreenPoint(healthBarTransform.position);
		}
		else {
			// we are offscreen, don't show
			showHealthBar = false;
		}
	}
}
