using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class PlayerColor{
	public Color panelColor;
	public Color textColor;
}

[System.Serializable]
public class Player{
	public Image panel;
	public Text text;
	public Button button;
}

public class GameController : MonoBehaviour {

	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;

	public Text[] buttonList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;
	public GameObject startInfo;

	private string playerSide;
	private int moveCount;

	public void GameStart()
	{
		SetGameControllerReferenceOnButtons();
		gameOverPanel.SetActive(false);
		moveCount = 0;
		restartButton.SetActive(false);
	}

	void StartPlaying()
	{
		SetBoardInteractable(true);
		SetPlayerButtons(false);
		startInfo.SetActive(false);
	}

	public void SetStartingSide(string startingSide)
	{
		playerSide = startingSide;
		if (playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		}
		else
		{
			SetPlayerColors(playerO, playerX);
		}
		StartPlaying();
	}

	void SetPlayerButtons(bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);

		}
	}

	void SetPlayerColors(Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}

	void SetPlayerColorsInactive()
	{
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;
		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}

	public void EndTurn()
	{
		moveCount ++;

		if (buttonList[1].text == playerSide && buttonList[2].text == playerSide && buttonList[3].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (buttonList[5].text == playerSide && buttonList[0].text == playerSide && buttonList[4].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (buttonList[1].text == playerSide && buttonList[5].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (buttonList[2].text == playerSide && buttonList[0].text == playerSide && buttonList[7].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (buttonList[1].text == playerSide && buttonList[0].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (buttonList[3].text == playerSide && buttonList[0].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver(playerSide);
		}
		else if (moveCount >= 9)
		{
			GameOver("draw");
		}
		else
		{
			ChangeSides();
		}
	}

	void GameOver(string winningPlayer)
	{
		SetBoardInteractable(false);
		if (winningPlayer == "draw")
		{
			SetGameOverText("It's draw!");
			SetPlayerColorsInactive();
		}else
		{
			SetGameOverText(winningPlayer + " Wins!");
		}
		restartButton.SetActive(true);
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
		if (playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		}
		else
		{
			SetPlayerColors(playerO, playerX);
		}
	}

	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}

	public void RestartGame()
	{
		moveCount = 0;
		gameOverPanel.SetActive(false);

		//SetBoardInteractable(true);
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].text = "";
		}
		restartButton.SetActive(false);
		SetPlayerButtons(true);
		SetPlayerColorsInactive();
		startInfo.SetActive(true);
	}

	void SetBoardInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}
}
