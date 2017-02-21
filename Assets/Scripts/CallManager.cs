using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CallManager : MonoBehaviour
{

	public InputField callInputField;
	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;
	public Button button6;
	public Button button7;
	public Button button8;
	public Button button9;
	public Button button0;
	public Button buttonStern;
	public Button buttonSharp;
	public Button backButton;
	public Button callButton;
	public Button refreshButton;
	public Text warningText;
	public AudioSource OnCallSound;
	public AudioClip ringingSound;
	public AudioClip messageSound;
	private AudioSource audioSource;
	private bool callButtonOn;
	private VirtualKeyboard vk;

	// Use this for initialization
	void Start()
	{
		vk = new VirtualKeyboard();

		callInputField.text = "";

		Button btn1 = button1.GetComponent<Button>();
		btn1.onClick.AddListener(Button1OnClick);

		Button btn2 = button2.GetComponent<Button>();
		btn2.onClick.AddListener(Button2OnClick);

		Button btn3 = button3.GetComponent<Button>();
		btn3.onClick.AddListener(Button3OnClick);

		Button btn4 = button4.GetComponent<Button>();
		btn4.onClick.AddListener(Button4OnClick);
		
		Button btn5 = button5.GetComponent<Button>();
		btn5.onClick.AddListener(Button5OnClick);
		
		Button btn6 = button6.GetComponent<Button>();
		btn6.onClick.AddListener(Button6OnClick);

		Button btn7 = button7.GetComponent<Button>();
		btn7.onClick.AddListener(Button7OnClick);
		
		Button btn8 = button8.GetComponent<Button>();
		btn8.onClick.AddListener(Button8OnClick);
		
		Button btn9 = button9.GetComponent<Button>();
		btn9.onClick.AddListener(Button9OnClick);
		
		Button btn0 = button0.GetComponent<Button>();
		btn0.onClick.AddListener(Button0OnClick);
		
		Button btnStern = buttonStern.GetComponent<Button>();
		btnStern.onClick.AddListener(ButtonSternOnClick);
		
		Button btnSharp = buttonSharp.GetComponent<Button>();
		btnSharp.onClick.AddListener(ButtonSharpOnClick);

		Button btnBack = backButton.GetComponent<Button>();
		btnBack.onClick.AddListener(BackButtonOnClick);

		Button btnRefresh = refreshButton.GetComponent<Button>();
		btnRefresh.onClick.AddListener(RefreshButtonOnClick);

		Button btnCall = callButton.GetComponent<Button>();
		btnCall.onClick.AddListener(CallButtonOnClick);
	}
	
	// Update is called once per frame
	void Update()
	{
		warningText.enabled = false;
		callButton.interactable = true;
		// Check entered phone number if valid

		if (IsPhoneNumber(callInputField.text) == false && callInputField.text.Length > 2)
		{
			callButton.interactable = true;
			warningText.enabled = true;
		} else if (WithSpecialNumber(callInputField.text))
		{
			callButton.interactable = false;
			warningText.enabled = true;
		} else if (callInputField.text.Length < 3)
		{
			callButton.interactable = false;
		} else
		{
			warningText.enabled = false;
		}
	}

	public void OpenKeyboard()
	{
		{       
			vk.ShowTouchKeyboard();
			//vk.ShowOnScreenKeyboard();
		}
	}
	
	public void CloseKeyboard()
	{
		{   
			vk.HideTouchKeyboard();
			//vk.HideOnScreenKeyboard();
		}
	}

	void Button1OnClick()
	{
		callInputField.text = callInputField.text + "1";
	}

	void Button2OnClick()
	{
		callInputField.text = callInputField.text + "2";
	}

	void Button3OnClick()
	{
		callInputField.text = callInputField.text + "3";
	}

	void Button4OnClick()
	{
		callInputField.text = callInputField.text + "4";
	}

	void Button5OnClick()
	{
		callInputField.text = callInputField.text + "5";
	}

	void Button6OnClick()
	{
		callInputField.text = callInputField.text + "6";
	}

	void Button7OnClick()
	{
		callInputField.text = callInputField.text + "7";
	}

	void Button8OnClick()
	{
		callInputField.text = callInputField.text + "8";
	}

	void Button9OnClick()
	{
		callInputField.text = callInputField.text + "9";
	}
	
	void Button0OnClick()
	{
		callInputField.text = callInputField.text + "0";
	}

	void ButtonSternOnClick()
	{
		callInputField.text = callInputField.text + "*";
	}

	void ButtonSharpOnClick()
	{
		callInputField.text = callInputField.text + "#";
	}

	void BackButtonOnClick()
	{
		if (callInputField.text.Length > 0)
		{
			callInputField.text = callInputField.text.Remove(callInputField.text.Length - 1);
		}
	}

	void RefreshButtonOnClick()
	{
		callInputField.text = "";
	}

	void CallButtonOnClick()
	{
		if (!warningText.enabled && callInputField.text.Length > 2)
		{
			StartCoroutine(playSound());
		}
	}

	bool IsPhoneNumber(string input)
	{
		string pattern = @"^(\d{3,4}\d{0,10})$";

		bool isMatach = Regex.IsMatch(input, pattern);

		return isMatach;
	}

	bool WithSpecialNumber(string input)
	{
		string pattern = @"^(((\*|\#)(\*|\#|[0-9])*)|([0-9](\*|\#)))$";
		
		bool isMatach = Regex.IsMatch(input, pattern);

		return isMatach;
	}

	IEnumerator WaitMoment()
	{
		warningText.enabled = true;
		yield return new WaitForSeconds(4);
	}

	void getPhoneNumber()
	{
		Debug.Log(callInputField.text);
		//return callInputField.text;
	}

	public void PlayCallSound()
	{
		StartCoroutine(playSound());
	}

	public void StopCallSound()
	{
		StopSound();
	}

	void StopSound()
	{
		OnCallSound.enabled = false;
	}

	IEnumerator playSound()
	{
		if (OnCallSound.enabled == false)
		{
			OnCallSound.enabled = true;
		}
		OnCallSound.clip = ringingSound;
		if (OnCallSound.enabled == true)
		{
			OnCallSound.Play();
		}
		yield return new WaitForSeconds(OnCallSound.clip.length);
		OnCallSound.clip = messageSound;
		if (OnCallSound.enabled == true)
		{
			OnCallSound.Play();
		}
	}
}
