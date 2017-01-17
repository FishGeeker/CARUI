using UnityEngine;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using UnityEngine.UI;

public class MailDisplay : MonoBehaviour
{
	
	public MailBlock mailBlockPrefab;
	//public GameObject callPanel, keyBoardPanel;
	public Text mailAdress, mailSubject, mailBody;
	
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

		foreach (Mail mail in SendingEmail.insMail.mailsDB.list)
		{
			MailBlock newBlock = Instantiate(mailBlockPrefab) as MailBlock;
			newBlock.transform.SetParent(transform, false);
			newBlock.Display(mail);
//			newBlock.GetComponent<Button>().onClick.AddListener(delegate {
//				ContactButtonOnClick(newBlock);
//			});
			//or use--> newBlock.GetComponent<Button>().onClick.AddListener(() => ContactButtonOnClick(newBlock));
		}
	}
	
	public void MailButtonOnClick(MailBlock mail)
	{
		//Debug.Log(mail.name);
		mailAdress.text = mail.MailAddress.text;
		mailSubject.text = mail.MailSubject.text;
		//callPanel.SetActive(true);
		//keyBoardPanel.SetActive(false);
	}
}
