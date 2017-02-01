using UnityEngine;
using System.Collections;

public class WikiTrace : MonoBehaviour {

	// Use this for initialization
	public void WikiTraceStart () {
		WebEditorWindow.Init();
	}

	public void WikiTraceClose(){
		WebEditorWindow.CloseWiki();
	}
}
