using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;	
using System.IO;

public class CallUserDataManager : MonoBehaviour
{
	public static CallUserDataManager ins;

	void Awake()
	{
		ins = this;
	}

	public ContactDatabase contactDB;
	//ContactDatabase contactDB1;

	public void WriteContacts()
	{

	}

	public void SaveContacts()
	{
		XmlSerializer ser = new XmlSerializer(typeof(ContactDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/callContact_data.xml", FileMode.Create);
		ser.Serialize(stream, contactDB);
		stream.Close();
	}

	public void AddContacts()
	{
		string xmlPath = Application.dataPath + "/StreamingFiles/callContact_data.xml";

		if (File.Exists(Application.dataPath + "/StreamingFiles/callContact_data.xml"))
		{
			XmlDocument XDoc = new XmlDocument();
			XDoc.Load(xmlPath);
			XmlElement Node = (XmlElement)XDoc.GetElementsByTagName("list") [0];

			if (Node != null)
			{
				bool contactExist=false;
				foreach (XmlNode xNode in Node)
				{
					XmlNode parent = xNode.FirstChild;
					if (parent.InnerText == "Apple2")
					{
						Debug.Log("User exists");
						contactExist=true;
					} 	
				}

				if (!contactExist) {
					XmlElement contactNode = XDoc.CreateElement("Contact");
					Node.AppendChild(contactNode);
					
					XmlElement nameNode = XDoc.CreateElement("name");
					XmlElement numberNode = XDoc.CreateElement("number");
					
					nameNode.InnerText = "Apple2";
					numberNode.InnerText = "12345";
					contactNode.AppendChild(nameNode);
					contactNode.AppendChild(numberNode);
				}
			}

			XDoc.Save(xmlPath);
		}
//		else
//		{
//			using (XmlWriter writer = XmlWriter.Create(localCopy))
//			{
//				writer.WriteStartDocument();
//				writer.WriteStartElement("Employees");
//				
//				foreach (Employee employee in employees)
//				{
//					writer.WriteStartElement("Employee");
//					
//					writer.WriteElementString("ID", employee.Id.ToString());
//					writer.WriteElementString("FirstName", employee.FirstName);
//					writer.WriteElementString("LastName", employee.LastName);
//					writer.WriteElementString("Salary", employee.Salary.ToString());
//					
//					writer.WriteEndElement();
//				}
//				
//				writer.WriteEndElement();
//				writer.WriteEndDocument();
//				writer.Close();
//				Console.WriteLine(localCopy);
//				Console.ReadLine();
//			}



		//XmlSerializer ser = new XmlSerializer(typeof(ContactDatabase));
//		FileStream stream = new FileStream(Application.dataPath+"/StreamingFiles/callContact_data.xml",FileMode.Append);
//
//		StreamWriter sw=new StreamWriter(stream);
//
//		sw.WriteLine("David Bull");
//		sw.WriteLine("15056022916");
//
//		sw.Close();
//		stream.Close();
	}

	public void LoadContacts()
	{
		XmlSerializer ser = new XmlSerializer(typeof(ContactDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/callContact_data.xml", FileMode.Open);
		contactDB = ser.Deserialize(stream) as ContactDatabase;

		stream.Close();
	}
}

[System.Serializable]
public class Contact
{
	public string name;
	public string number;
}

[System.Serializable]
public class ContactDatabase
{
	public List<Contact> list = new List<Contact>();
}