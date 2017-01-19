using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MailBlock : MonoBehaviour
{
	
	public Text MailAddress, MailSubject, MailTime, MailBody;
	public Text MailFullTime;

	void start()
	{
		MailFullTime.text="dd.MM.yyyy HH:mm:ss";
	}

	public void Display(Mail mail)
	{
		MailAddress.text = mail.adress;
		MailSubject.text = mail.subject;
		MailBody.text = mail.body;

		DateTime dt=DateTime.Parse(mail.time.ToString());
		MailTime.text = dt.ToString("dd.MM.yyyy");
		MailFullTime.text = dt.ToString("dd.MM.yyyy HH:mm:ss");
	}
}

