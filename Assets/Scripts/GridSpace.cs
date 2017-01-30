using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button;
	public Text buttonText;

	private GameController gameController;
	private int index;
	private ArrayList indexList;

	public void SetSpace()
	{
		buttonText.text = gameController.GetPlayerSide();
		button.interactable = false;
		gameController.EndTurn();

		StartCoroutine(RandomSetButton());
	}

	public void SetGameControllerReference(GameController controller)
	{
		gameController = controller;
	}

	//After 1 second, random set a button from interactable buttons using Coroutine
	IEnumerator RandomSetButton()
	{
		yield return new WaitForSeconds(1);
		indexList=new ArrayList();

		//get all interactable buttons into a list
		for (int i = 0; i < gameController.buttonList.Length; i++)
		{
			if (gameController.buttonList[i].GetComponentInParent<Button>().interactable == true)
			{
				indexList.Add(i);
			}
		}

		//if list contains one interactable button, then set
		if(indexList.Count>0)
		{
			index = Random.Range(0, indexList.Count);
			
			gameController.buttonList[(int)indexList[index]].GetComponentInParent<Text>().text = gameController.GetPlayerSide();
			gameController.buttonList[(int)indexList[index]].GetComponentInParent<Button>().interactable = false;
			gameController.EndTurn();
		}
	}
}
