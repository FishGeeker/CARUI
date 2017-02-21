using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusDataManager : MonoBehaviour
{

	public Text fuelLevel;
	public Text speed;
	public Text frontDistance, backDistance, leftDistance, rightDistance;
	public Button pedestrian, roadwork, slickRoad;
	public Button redLight, greenLight, yellowLight;
	public AudioSource warningSound;
	public AudioClip roadEnvironmentWarningSound, carEnvironmentWarningSound;
	private int fuelLevelValue;
	private int speedValue;
	private int frontDistanceValue, leftDistanceValue, rightDistanceValue, backDistanceValue;
	private bool hasPedestrian, hasRoadWork, hasSlickRoad;
	private bool redLightOn, greenLightOn, yellowLightOn;

	// Use this for initialization
	void Start()
	{
		fuelLevelValue = 100;
		speedValue = 0;
		frontDistanceValue = 100;
		backDistanceValue = 500;
		leftDistanceValue = 3;
		rightDistanceValue = 5;
		
		hasPedestrian = false;
		hasRoadWork = false;
		hasSlickRoad = false;

		redLightOn = false;
		greenLightOn = false;
		yellowLightOn = false;
	}

	// Update is called once per frame
	void Update()
	{
		fuelLevelValue = fuelLevelValue - 1;
		speedValue = speedValue + 1;
		frontDistanceValue = frontDistanceValue - 1;
		backDistanceValue = backDistanceValue - 1;
		leftDistanceValue = leftDistanceValue - 1;
		rightDistanceValue = rightDistanceValue - 1;

		hasPedestrian = true;
		hasRoadWork = false;
		hasSlickRoad = false;

		greenLightOn = true;
		redLightOn = false;
		yellowLightOn = false;

		SetFuelLevel();
		SetSpeed();
		SetFrontDistance();
		SetBackDistance();
		SetLeftDistance();
		SetRightDistance();

		//CheckRoadStatus();
		CheckRoad();
		CheckCarStatus();
		CheckLights();
	}

	void CheckLights()
	{
		if (greenLightOn)
		{
			SetLightOn(greenLight);
		} else
		{
			SetLightOff(greenLight);
		}
		if (redLightOn)
		{
			SetLightOn(redLight);
		} else
		{
			SetLightOff(redLight);
		}
		if (yellowLightOn)
		{
			SetLightOn(yellowLight);
		} else
		{
			SetLightOff(yellowLight);
		}
	}

	void SetLightOn(Button light)
	{
		SetZeichen(true, light);
	}

	void SetLightOff(Button light)
	{
		SetZeichen(false, light);
	}

	// Check FuelLevel, speed, front-back-left-right Distance of car
	void CheckCarStatus()
	{
		if (fuelLevelValue < 0)
		{
			StartCarStatusWarning(fuelLevel);
		} else
		{
			CancelCarStatusWarning(fuelLevel);
		}
		if (speedValue > 120)
		{
			StartCarStatusWarning(speed);
		} else
		{
			CancelCarStatusWarning(speed);
		}
		if (frontDistanceValue < 10)
		{
			StartCarStatusWarning(frontDistance);
		} else
		{
			CancelCarStatusWarning(frontDistance);
		}
		if (leftDistanceValue < 1)
		{
			StartCarStatusWarning(leftDistance);
		} else
		{
			CancelCarStatusWarning(leftDistance);
		}
		if (backDistanceValue < 10)
		{
			StartCarStatusWarning(backDistance);
		} else
		{
			CancelCarStatusWarning(backDistance);
		}
		if (rightDistanceValue < 1)
		{
			StartCarStatusWarning(rightDistance);
		} else
		{
			CancelCarStatusWarning(rightDistance);
		}
	}

	void StartCarStatusWarning(Text InfoText)
	{
		InfoText.color = Color.red;
	}

	void CancelCarStatusWarning(Text InfoText)
	{
		InfoText.color = Color.white;
	}

	//set values for car status 
	void SetFuelLevel()
	{
		fuelLevel.text = fuelLevelValue.ToString();
	}
	
	void SetSpeed()
	{
		speed.text = speedValue.ToString();
	}
	
	void SetFrontDistance()
	{
		frontDistance.text = frontDistanceValue.ToString();
	}

	void SetBackDistance()
	{
		backDistance.text = backDistanceValue.ToString();
	}

	void SetLeftDistance()
	{
		leftDistance.text = leftDistanceValue.ToString();
	}

	void SetRightDistance()
	{
		rightDistance.text = rightDistanceValue.ToString();
	}

	void CheckRoadStatus()
	{
		if (hasPedestrian == true)
		{
			StartRoadStatusWarning(pedestrian);
		} else
		{
			CancelRoadStatusWarning(pedestrian);
		}
		if (hasRoadWork == true)
		{
			StartRoadStatusWarning(roadwork);
		} else
		{
			CancelRoadStatusWarning(roadwork);
		}
		if (hasSlickRoad == true)
		{
			StartRoadStatusWarning(slickRoad);
		} else
		{
			CancelRoadStatusWarning(slickRoad);
		}
	}

	/// <summary>
	/// Checks the road.
	/// </summary>
	void CheckRoad()
	{
		if (hasPedestrian == true)
		{
			this.InvokeRepeating("RoadStatusWarning1", 1.0f, 2.0f);
			this.InvokeRepeating("RoadStatusWarning2", 2.0f, 2.0f);
		}
		else
		{
			RoadStatusWarning2();
		}
	}

	void RoadStatusWarning1()
	{
		StartRoadStatusWarning(pedestrian);
	}
	void RoadStatusWarning2()
	{
		CancelRoadStatusWarning(pedestrian);
	}
	////*/*/*/*/*/*/*/**/*/*/*/*/*/*/*/

	void StartRoadStatusWarning(Button zeichen)
	{
		SetZeichen(true, zeichen);
	}

	void CancelRoadStatusWarning(Button zeichen)
	{
		SetZeichen(false, zeichen);
	}

	//Used to set warning symbol
	void SetZeichen(bool isWarning, Button zeichen)
	{
		var col = zeichen.image.color;
		if (isWarning)
		{
			col.a = 1;
		} else
		{
			col.a = (float)0.176;
		}
		zeichen.image.color = col;
	}
}
