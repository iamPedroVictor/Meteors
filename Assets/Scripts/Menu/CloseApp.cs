using System;
using UnityEngine;
using UnityEngine.UI;

public class CloseApp : MonoBehaviour {

    public GameObject QuitPanel;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CallCloseApp();
        }
	}

    public void CallCloseApp()
    {
        QuitPanel.SetActive(true);
    }

    public void CancelCloseApp()
    {
        QuitPanel.SetActive(false);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
