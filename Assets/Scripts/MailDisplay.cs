using UnityEngine;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using UnityEngine.UI;

public class MailDisplay : MonoBehaviour
{
	
	public MailBlock mailBlockPrefab;
	//public GameObject callPanel, keyBoardPanel;
	public Text mailAdress, mailSubject, mailBody, mailTime;
	public GameObject mailContentPanel;
	
	void Start()
	{
		Display();
	}
	
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
}
