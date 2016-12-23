using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContactBlock : MonoBehaviour
{

	public Text ContactName, ContactNumber;

	public void Display(Contact contact)
	{
		ContactName.text=contact.name;
		ContactNumber.text=contact.number;
	}

}
