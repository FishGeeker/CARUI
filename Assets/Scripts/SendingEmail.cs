using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;	
using System.IO;
using System.Text.RegularExpressions;
using System;

public class SendingEmail : MonoBehaviour
{
	public static SendingEmail insMail;
	//public Text warningMail;
	
	void Awake()
	{
		insMail = this;
		//warningMail.enabled = false;
	}
	
	public MailsDatabase mailsDB;
	public InputField mailAdress, mailSubject, mailBody;

	public void AfterSendingInitialize()
	{
		mailAdress.text="";
		mailSubject.text="";
		mailBody.text="";
	}

	public void CheckAddress()
	{
		//warningMail.enabled = false;
		Text text = mailAdress.transform.FindChild("Text").GetComponent<Text>();
		text.color = Color.black;
		if (IsMailAddress(mailAdress.text) == false)
		{
			Debug.Log("This is not mailaddress!");
			//warningMail.enabled = true;
			Debug.Log(System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
			Debug.Log(System.DateTime.Now.ToString("dd.MM.yyyy"));

			text.color = Color.red;
		} else
		{
			Debug.Log("This is mailaddress!");
			//warningMail.enabled = false;
			text.color = Color.black;
		}
	}

	bool IsMailAddress(string input)
	{
		string pattern = @"^\w+@\w+\.\w+$";
		
		bool isMatach = Regex.IsMatch(input, pattern);
		
		return isMatach;
	}

	public Mail WriteMail()
	{
		Mail email = new Mail();
		email.adress = mailAdress.text;
		email.subject = mailSubject.text;
		email.body = mailBody.text;
		email.time = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
//		email.adress = "florianzhang@";
//		email.subject = "My Subject:test";
//		email.body = "My Body Full of non-escaped chars";
		return email;
	}

	public MailsDatabase SendMail()
	{
		mailsDB.list.Add(WriteMail());
		return mailsDB;
	}

	public void SaveMail()
	{
		string xmlPath = Application.dataPath + "/StreamingFiles/Mails_data.xml";
		
		if (File.Exists(Application.dataPath + "/StreamingFiles/Mails_data.xml"))
		{
			XmlDocument XDoc = new XmlDocument();
			XDoc.Load(xmlPath);
			XmlElement Node = (XmlElement)XDoc.GetElementsByTagName("list") [0];
			
			if (Node != null)
			{
				XmlElement mailNode = XDoc.CreateElement("Mail");
				Node.AppendChild(mailNode);
					
				XmlElement adressNode = XDoc.CreateElement("adress");
				XmlElement subjectNode = XDoc.CreateElement("subject");
				XmlElement bodyNode = XDoc.CreateElement("body");
				XmlElement timeNode = XDoc.CreateElement("time");
                    
				adressNode.InnerText = mailAdress.text;
				subjectNode.InnerText = mailSubject.text;
				bodyNode.InnerText = mailBody.text;
				timeNode.InnerText = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				mailNode.AppendChild(adressNode);
				mailNode.AppendChild(subjectNode);
				mailNode.AppendChild(bodyNode);
				mailNode.AppendChild(timeNode);
			}
            
			XDoc.Save(xmlPath);
			Debug.Log("send succeed!");
		} else
		{
			XmlSerializer ser = new XmlSerializer(typeof(MailsDatabase));
			FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/Mails_data.xml", FileMode.Create);
			ser.Serialize(stream, SendMail());
			stream.Close();
			Debug.Log("send succeed!");
		}
	}

	public void LoadMails()
	{
		XmlSerializer ser = new XmlSerializer(typeof(MailsDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/Mails_data.xml", FileMode.Open);
		mailsDB = ser.Deserialize(stream) as MailsDatabase;
		
		stream.Close();
	}
}

[System.Serializable]
public class Mail
{
	public string adress;
	public string subject;
	public string body;
	public string time;
}

[System.Serializable]
public class MailsDatabase
{
	public List<Mail> list = new List<Mail>();
}
