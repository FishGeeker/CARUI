using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDataManager : MonoBehaviour
{

	public Text fuelLevel;
	public Text speed;
	public Text frontDistance;

	private int fuelLevelValue;
	private int speedValue;
	private int frontDistanceValue;

	// Use this for initialization
	void Start()
	{
		fuelLevelValue = 0;
		speedValue = 0;
		frontDistanceValue=0;

		SetFuelLevel();
		SetSpeed();
		SetfrontDistance();
	}

	// Update is called once per frame
	void Update()
	{
		fuelLevelValue++;
		speedValue++;
		frontDistanceValue++;

		SetFuelLevel();
		SetSpeed();
		SetfrontDistance();
	}

	//set values
	void SetFuelLevel()
	{
		fuelLevel.text = "Fuel Level: " + fuelLevelValue.ToString();
	}

	void SetSpeed()
	{
		speed.text = "Speed: " + speedValue.ToString();
	}

	void SetfrontDistance()
	{
		frontDistance.text=frontDistanceValue.ToString();
	}
}
