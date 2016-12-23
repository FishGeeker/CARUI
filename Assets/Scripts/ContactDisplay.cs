using UnityEngine;
using System.Collections;


public class ContactDisplay : MonoBehaviour
{

	public ContactBlock blockPrefab;

	void Start()
	{
		Display();
	}

	public void Display()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}

		foreach (Contact contact in CallUserDataManager.ins.contactDB.list)
		{
			ContactBlock newBlock = Instantiate(blockPrefab) as ContactBlock;
			newBlock.transform.SetParent(transform, false);
			newBlock.Display(contact);
		}
	}
}
