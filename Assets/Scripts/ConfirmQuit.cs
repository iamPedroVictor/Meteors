using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmQuit : MonoBehaviour {

    public GameObject QuitGamePanel;
    private bool panelActive;
    private void Awake()
    {
        QuitGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            PanelQuitGame();
        }
	}

    public void QuitGame(){
        Application.Quit();
    }

    public void PanelQuitGame() {
        panelActive = !panelActive;
        QuitGamePanel.SetActive(panelActive);
    }

}
