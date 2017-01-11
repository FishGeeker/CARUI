using UnityEngine;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using UnityEngine.UI;

public class ContactDisplay : MonoBehaviour
{

	public ContactBlock blockPrefab;
	public GameObject callPanel;
	public Text callName, callNumber;

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
			newBlock.GetComponent<Button>().onClick.AddListener(delegate{ContactButtonOnClick(newBlock);});
			//or use--> newBlock.GetComponent<Button>().onClick.AddListener(() => ContactButtonOnClick(newBlock));
		}
	}

	public void ContactButtonOnClick(ContactBlock contact){
		Debug.Log(contact.name);
		callName.text=contact.ContactName.text;
		callNumber.text=contact.ContactNumber.text;
		callPanel.SetActive(true);
	}
}
