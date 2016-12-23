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
		ins=this;
	}

	public ContactDatabase contactDB;
	//ContactDatabase contactDB1;

	public void WriteContacts()
	{

	}

	public void SaveContacts()
	{
		XmlSerializer ser = new XmlSerializer(typeof(ContactDatabase));
		FileStream stream = new FileStream(Application.dataPath+"/StreamingFiles/callContact_data.xml",FileMode.Create);
		ser.Serialize(stream,contactDB);
		stream.Close();
	}

	public void AddContacts()
	{
		//XmlSerializer ser = new XmlSerializer(typeof(ContactDatabase));
		FileStream stream = new FileStream(Application.dataPath+"/StreamingFiles/callContact_data.xml",FileMode.Append);

		StreamWriter sw=new StreamWriter(stream);
		sw.WriteLine("David Bull");
		sw.WriteLine("15056022916");

		sw.Close();
		stream.Close();
	}

	public void LoadContacts()
	{
		XmlSerializer ser=new XmlSerializer(typeof(ContactDatabase));
		FileStream stream=new FileStream(Application.dataPath+"/StreamingFiles/callContact_data.xml",FileMode.Open);
		contactDB=ser.Deserialize(stream) as ContactDatabase;
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