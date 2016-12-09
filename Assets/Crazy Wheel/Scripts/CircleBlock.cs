using UnityEngine;
using System.Collections;

public class CircleBlock : MonoBehaviour {
	
	internal Controller gameController;
	internal Dial DialController;

	//This object's sprite renderer. We will change this based on the current color set above
	internal SpriteRenderer ObjRenderer;

	[Tooltip("The index of the color of this object as defined in the controller")]
	public int colorIndex = 0;

	// Use this for initialization
	void Start () 
	{
		//Get the sprite renderer of this game object
		ObjRenderer=GetComponent<SpriteRenderer>();

		// Get the game controller
		if (gameController == null)    gameController =(Controller)FindObjectOfType(typeof(Controller));
		//Get the dial controller
		if (DialController == null)    DialController =(Dial)FindObjectOfType(typeof(Dial));
	}

	//Executes when the dial comes into contact with one of the circle walls
	void OnTriggerEnter2D(Collider2D other)
	{	 
		//Send this block's color index to the dial controller for comparison
		DialController.currentBlockColor=colorIndex;
	}

	//Executes when the dial exits the circle walls
	void OnTriggerExit2D(Collider2D other)
	{	 
		//Check if the dial and circle block colors match but the player failed to press the button on time
		if(DialController.currentColor==colorIndex)
			gameController.GameOver();
	}

	public void SetColor()
	{
		// Set the objects color
		ObjRenderer.color=gameController.colorList[colorIndex];
	}
}
