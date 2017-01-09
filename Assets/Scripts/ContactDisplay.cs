using UnityEngine;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

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

		foreach (Contact contact in CallUserDataManager.ins.contactDB.list.OrderBy(o=>o.name).ToList())
		{
			ContactBlock newBlock = Instantiate(blockPrefab) as ContactBlock;
			newBlock.transform.SetParent(transform, false);
			newBlock.Display(contact);
		}
	}
}
