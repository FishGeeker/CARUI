using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnCallNumber : MonoBehaviour {

	public Text onCallNumber;
	public InputField inputNumber;
	public Button cancelButton;
	public AudioClip ringingSound;
	public AudioClip messageSound;

	private AudioSource audioSource;
	private string number;

//	void awake()
//	{
//
//	}

	void Start()
	{
		InputField inputNum=inputNumber.GetComponent<InputField>();
		number=inputNum.text;
		Debug.Log(inputNum.GetComponent<PhoneNumber>().callInputField.text);


		SetCallNumber();
		//StartCoroutine(SoundOn());
	}

	void update()
	{
		InputField inputNum=inputNumber.GetComponent<InputField>();
		number=inputNum.text;
		Debug.Log(inputNum.GetComponent<PhoneNumber>().callInputField.text);
		SetCallNumber();
		//StartCoroutine(SoundOn());
	}

	void SetCallNumber()
	{
		onCallNumber.text = "OnCallNumber:"+number;
	}

	IEnumerator SoundOn()
	{
		audioSource = cancelButton.GetComponent<AudioSource>();
		audioSource.clip = ringingSound;
		audioSource.Play();
		yield return new WaitForSeconds(4);
		audioSource.Play();
		yield return new WaitForSeconds(4);
		audioSource.clip = messageSound;
		audioSource.Play();
	}
}
