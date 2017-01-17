using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MailBlock : MonoBehaviour
{
	
	public Text MailAddress, MailSubject, MailBody;
	
	public void Display(Mail mail)
	{
		MailAddress.text = mail.adress;
		MailSubject.text = mail.subject;
//		MailBody.text = mail.body;
	}
	
}

