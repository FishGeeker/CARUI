using UnityEngine;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using UnityEngine.UI;

public class MailDisplay : MonoBehaviour
{
	
	public MailBlock mailBlockPrefab, mailContactBlockPrefab;
	public Text mailAdress, mailSubject, mailBody, mailTime;
	public GameObject mailContentPanel, newMailPanel, contactsPanel;
	public InputField addressInMailPanel;
	
	public void Display()
	{
		// delete previous blocks
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}

		foreach (Mail mail in SendingEmail.insMail.mailsDB.list.OrderByDescending(e => e.time).ToList())
		{
			MailBlock newBlock = Instantiate(mailBlockPrefab) as MailBlock;
			newBlock.transform.SetParent(transform, false);
			newBlock.Display(mail);
			newBlock.GetComponent<Button>().onClick.AddListener(delegate {
				MailButtonOnClick(newBlock);	//with newBlock other than mail, otherwise causes the same output
			});
			//or use--> newBlock.GetComponent<Button>().onClick.AddListener(() => ContactButtonOnClick(newBlock));
		}
	}
	
	public void MailButtonOnClick(MailBlock mail)
	{
		//Debug.Log(mail.name);
		mailSubject.text = mail.MailSubject.text;
		mailAdress.text = mail.MailAddress.text;
		mailTime.text = mail.MailFullTime.text;
		mailBody.text = mail.MailBody.text;

		mailContentPanel.SetActive(true);
		//keyBoardPanel.SetActive(false);
	}

	public void MailContactsDisplay()
	{
		// delete previous blocks
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}

		//collect all Mailaddresses
		ArrayList addressList = new ArrayList();
		foreach (Mail mail in SendingEmail.insMail.mailsDB.list)
		{
			addressList.Add(mail.adress);
		}

		//remove same addresses
		int n = addressList.Count - 1;
		for (int i = addressList.Count - 1; i >= 0; i--)
		{
			n = addressList.IndexOf(addressList [i], 0);
			if (n >= 0 && n != i)
			{
				addressList.RemoveAt(i);
			}
		}

		//sort list alphabetically
		addressList.Sort();

		//output those addresses on the GUI
		foreach (string item in addressList)
		{
			
			MailBlock newBlock = Instantiate(mailContactBlockPrefab) as MailBlock;
			newBlock.transform.SetParent(transform, false);
			newBlock.ContactsDisplay(item);
			newBlock.GetComponent<Button>().onClick.AddListener(delegate {
				AddressButtonOnClick(newBlock);	//with newBlock other than mail, otherwise causes the same output
			});
			//or use--> newBlock.GetComponent<Button>().onClick.AddListener(() => ContactButtonOnClick(newBlock));
		}
	}

	public void AddressButtonOnClick(MailBlock mail)
	{
		newMailPanel.SetActive(true);
		contactsPanel.SetActive(false);
		addressInMailPanel.text = mail.MailAddress.text;
		Text text = addressInMailPanel.transform.FindChild("Text").GetComponent<Text>();
		text.color = Color.black;

		Debug.Log(addressInMailPanel.text);
	}
}
