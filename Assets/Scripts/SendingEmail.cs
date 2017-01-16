using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;	
using System.IO;

public class SendingEmail : MonoBehaviour
{
	public static SendingEmail insMail;
	
	void Awake()
	{
		insMail = this;
	}
	
	public MailsDatabase mailsDB;
	public InputField mailAdress, mailSubject, mailBody;

	public Mail WriteMail()
	{
		Mail email = new Mail();
		email.adress = mailAdress.text;
		email.subject = mailSubject.text;
		email.body = mailBody.text;
		//		email.adress = "florianzhang@126.com";
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
                    
				adressNode.InnerText = mailAdress.text;
				subjectNode.InnerText = mailSubject.text;
				bodyNode.InnerText = mailBody.text;
				mailNode.AppendChild(adressNode);
				mailNode.AppendChild(subjectNode);
				mailNode.AppendChild(bodyNode);
			}
            
			XDoc.Save(xmlPath);
			Debug.Log("send succeed!");
		} 
		else
		{
			XmlSerializer ser = new XmlSerializer(typeof(MailsDatabase));
			FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/Mails_data.xml", FileMode.Create);
			ser.Serialize(stream, SendMail());
			stream.Close();
			Debug.Log("send succeed!");
		}
	}
}

[System.Serializable]
public class Mail
{
	public string adress;
	public string subject;
	public string body;
}

[System.Serializable]
public class MailsDatabase
{
	public List<Mail> list = new List<Mail>();
}
