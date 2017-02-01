﻿using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

public class WebEditorWindow : EditorWindow
{
	static WebEditorWindow window;
	static string Url = "http://thewikigame.com/speed-race";

	[MenuItem ("Window/WikiWindow")]
	public static void Init() {
		window = WebEditorWindow.GetWindow<WebEditorWindow>();
		window.Show();
		OpenWebView(window);
	}

	public static void CloseWiki() {
		//window = WebEditorWindow.GetWindow<WebEditorWindow>();
		window.Close();
		//OpenWebView(window);
    }
    
	static void OpenWebView(WebEditorWindow window)
	{
		var thisWindowGuiView = typeof(EditorWindow).GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(window);
		
		Type webViewType = GetTypeFromAllAssemblies("WebView");
		var webView = ScriptableObject.CreateInstance(webViewType);
		
		Rect webViewRect = new Rect(0, 0, 1024, window.position.height);
		webViewType.GetMethod("InitWebView").Invoke(webView, new object[]{thisWindowGuiView, (int)webViewRect.x, (int)webViewRect.y, (int)webViewRect.width, (int)webViewRect.height, true});
		webViewType.GetMethod("LoadURL").Invoke(webView, new object[]{Url});
	}
	
	public static Type GetTypeFromAllAssemblies(string typeName) {
		Assembly[] assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
		foreach(Assembly assembly in assemblies) {
			Type[] types = assembly.GetTypes();
			foreach(Type type in types) {
				if(type.Name.Equals(typeName, StringComparison.CurrentCultureIgnoreCase) || type.Name.Contains('+' + typeName)) //+ check for inline classes
					return type;
			}
		}
		return null;
	}
}