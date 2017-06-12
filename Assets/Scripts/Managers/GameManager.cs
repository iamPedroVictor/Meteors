using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum GameState{
	Pause = 0,
	GamePlay = 1,
	GameOver = -1
}

public class GameManager : MonoBehaviour {

	private static GameManager _instance;

	public static GameManager Instance
	{
		get{
			if (_instance == null){
				_instance = FindObjectOfType<GameManager>();
			}
			return _instance;
		}
	}

	public GameObject GameOverPanel, GamePlayPanel, PausePanel;
	public GameState state;
	public int points;
	public int time;
	public Text timeText;

    public Text finalTimeText;
    public Text recordText;

    public Animator worldAnimator;

	private void Awake(){
		state = GameState.GamePlay;
		GameOverPanel.SetActive (false);
		PausePanel.SetActive (false);
		GamePlayPanel.SetActive (true);
		points = time = 0;
		InvokeRepeating ("Time", 1f, 1f);

	}

	private void Time(){
		time++;
		timeText.text = time.ToString ();
	}
		
	public void GameOver(){
        worldAnimator.SetTrigger("Destroy");
        GameOverSettings();

    }

    public void GameOverSettings() {
        state = GameState.GameOver;
        GameOverPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
        PausePanel.SetActive(false);
        CancelInvoke("Time");
        finalTimeText.text = "" + time;
        MeteorsManager.Instance.CancelMeteorsInvoke();
        if(time > PlayerPrefs.GetInt("RecordTime"))
        {
            SaveRecord(time);
        }

        recordText.text = ""+PlayerPrefs.GetInt("RecordTime");
    }

    public void SaveRecord(int newTime)
    {
        PlayerPrefs.SetInt("RecordTime", newTime);
    }
}
