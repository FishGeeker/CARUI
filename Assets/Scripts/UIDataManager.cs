using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDataManager : MonoBehaviour
{

	public Text fuelLevel;
	public Text speed;
	public Text frontDistance;

	public Button pedestrian, roadwork, slickRoad;
	//public AudioSource clip;

	private int fuelLevelValue;
	private int speedValue;
	private int frontDistanceValue;

	private bool hasPedestrian, hasRoadWork, hasSlickRoad;

	// Use this for initialization
	void Start()
	{
		fuelLevelValue = 0;
		speedValue = 0;
		frontDistanceValue=0;

		hasPedestrian = false;
		hasRoadWork = false;
		hasSlickRoad = false;
	}

	// Update is called once per frame
	void Update()
	{
		fuelLevelValue++;
		speedValue++;
		frontDistanceValue++;

		hasPedestrian = true;
		hasRoadWork = true;
		hasSlickRoad = true;

		SetFuelLevel();
		SetSpeed();
		SetfrontDistance();

		if (hasPedestrian)
		{
			startWarning(pedestrian);
		}
		if (hasRoadWork)
		{
			//startWarning(roadwork);
        }
		if (hasSlickRoad)
		{
			//startWarning(slickRoad);
        }
	}

	void startWarning(Button zeichen)
	{
		StartCoroutine(SetWarning(zeichen));
	}

	IEnumerator SetWarning(Button zeichen)
	{
        yield return new WaitForSeconds(1);

        SetZeichen(true, zeichen);
		yield return new WaitForSeconds(1);
		SetZeichen(false, zeichen);
	}

	//set values
	void SetFuelLevel()
	{
		fuelLevel.text = fuelLevelValue.ToString();
	}

	void SetSpeed()
	{
		speed.text = speedValue.ToString();
	}

	void SetfrontDistance()
	{
		frontDistance.text=frontDistanceValue.ToString();
	}

	void SetZeichen(bool isPedestrian, Button zeichen)
	{
		var col=zeichen.image.color;
		if (isPedestrian)
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
}
