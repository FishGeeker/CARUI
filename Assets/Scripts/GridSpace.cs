﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button;
	public Text buttonText;

	private GameController gameController;

	public void SetSpace()
	{
		buttonText.text = gameController.GetPlayerSide();
		button.interactable = false;
		gameController.EndTurn();

		RandomSetButton();
	}

	public void SetGameControllerReference(GameController controller)
	{
		gameController = controller;
	}

	void RandomSetButton()
	{
		gameController.buttonList[0].GetComponentInParent<Text>().text = gameController.GetPlayerSide();
		gameController.buttonList[0].GetComponentInParent<Button>().interactable = false;
		gameController.EndTurn();
	}
}
