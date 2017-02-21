using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class WikiRace : MonoBehaviour
{

//	#if UNITY_STANDALONE_WIN || UNITY_EDITOR
//	[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
//	private static extern bool SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
//	[DllImport("user32.dll", EntryPoint = "FindWindow")]
//	public static extern IntPtr FindWindow(System.String className, System.String windowName);
//	
//	public static void SetPosition(int x, int y, int resX = 0, int resY = 0) {
//		SetWindowPos(FindWindow(null, "Google Chrome"), 0, x, y, resX, resY, resX * resY == 0 ? 1 : 0);
//	}
//	#endif
//	
//	// Use this for initialization
//	void Awake()
//	{
//		SetPosition(100, 500);
//	}

	public void WikiRaceStart()
	{
		Application.OpenURL("http://www.thewikigame.com/");
	}
}