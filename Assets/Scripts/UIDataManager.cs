using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDataManager : MonoBehaviour
{

	public Text fuelLevel;
	public Text speed;
	public Text frontDistance, backDistance, leftDistance, rightDistance;

	public Button pedestrian, roadwork, slickRoad;
	public AudioSource warningSound;
	public AudioClip roadEnvironmentWarningSound, carEnvironmentWarningSound;

	private int fuelLevelValue;
	private int speedValue;
	private int frontDistanceValue, leftDistanceValue, rightDistanceValue, backDistanceValue;

	private bool hasPedestrian, hasRoadWork, hasSlickRoad;
	//private bool playRoadWarningSound, playCarWarningSound;

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

		//playCarWarningSound = false;
		//playRoadWarningSound = false;
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
		hasRoadWork = true;
		hasSlickRoad = true;

		SetFuelLevel();
		SetSpeed();
		SetFrontDistance();
		SetBackDistance();
		SetLeftDistance();
		SetRightDistance();

		CheckRoadStatus();
		CheckCarStatus();
	}

	// Check FuelLevel, speed, front-back-left-right Distance of car
	void CheckCarStatus()
	{
		if (fuelLevelValue<0)
		{
			StartCarStatusWarning(fuelLevel);
		}
		if (speedValue>120)
		{
			StartCarStatusWarning(speed);
		}
		if (frontDistanceValue<10)
		{
			StartCarStatusWarning(frontDistance);
		}
		if (leftDistanceValue<1)
		{
			StartCarStatusWarning(leftDistance);
		}
		if (backDistanceValue<10)
		{
			StartCarStatusWarning(backDistance);
		}
		if (rightDistanceValue<1)
		{
			StartCarStatusWarning(rightDistance);
		}
	}

	void StartCarStatusWarning(Text InfoText)
	{
		//playCarWarningSound = true;
		InfoText.color = Color.red;
		//PlaySingle(carEnvironmentWarningSound, playCarWarningSound);
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
		frontDistance.text=frontDistanceValue.ToString();
	}

	void SetBackDistance()
	{
		backDistance.text=backDistanceValue.ToString();
	}

	void SetLeftDistance()
	{
		leftDistance.text=leftDistanceValue.ToString();
	}

	void SetRightDistance()
	{
		rightDistance.text=rightDistanceValue.ToString();
	}

	void CheckRoadStatus()
	{
		if (hasPedestrian==true)
		{
			StartRoadStatusWarning(pedestrian);
		}
		if (hasRoadWork==true)
		{
			//StartRoadStatusWarning(roadwork);
		}
		if (hasSlickRoad==true)
		{
			//StartRoadStatusWarning(slickRoad);
		}
	}

	void StartRoadStatusWarning(Button zeichen)
	{
		//playRoadWarningSound = true;
		StartCoroutine(SetRoadStatusWarning(zeichen));
	}

	IEnumerator SetRoadStatusWarning(Button zeichen)
	{
        yield return new WaitForSeconds(1);

        SetZeichen(true, zeichen);

		//PlaySingle(roadEnvironmentWarningSound, playRoadWarningSound);
	}

	//Used to set warning symbol clear
	void SetZeichen(bool isWarning, Button zeichen)
	{
		var col=zeichen.image.color;
		if (isWarning)
		{
			col.a=1;
			zeichen.enabled=true;
		}
		else
		{
			col.a=(float)0.176;
			zeichen.enabled=false;
		}
		zeichen.image.color=col;
	}

	//Used to play single sound clips.
	public void PlaySingle(AudioClip clip, bool onPlay)
	{
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		warningSound.clip = clip;
		
		//Play the clip.
		//warningSound.Play ();

		if(onPlay)
		{
			
			warningSound.PlayOneShot(clip);//use the same check for runSound
			onPlay = false;
		}
	}
}
