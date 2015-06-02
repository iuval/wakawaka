using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreMenu : MonoBehaviour {
	
	Animator anim;
	public Text descriptionText;
	public Button useButton;
	public GameMenu gameMenu;
	
	int currentIndex = 0;
	
	void Awake () {
		anim = GetComponentInChildren<Animator> ();
	}
	
	void Start () {
		currentIndex = PlayerPrefs.GetInt("current_skin_index");
		ChangeTo(currentIndex);
	}

	void Update () {
	
	}
	
	public void Show() {
		gameObject.SetActive(true);
		anim.SetTrigger("show");
	}
	
	public void Hide() {
		anim.SetTrigger("hide");
	}
	
	public void Back() {
		Hide();
		gameMenu.Show();
	}
	
	void Hidden() {
		gameObject.SetActive(false);
	}
	
	public void UserCurrent() {
		PlayerPrefs.SetInt("current_skin_index", currentIndex);
	}
	
	public void ChangeTo(int index) {
		currentIndex = index;
		string text = "";
		bool canUse = false;
		int totalThings = GameController.GetTotalTaps();
		int totalTime = GameController.GetTotalTime();
		int totalGames = GameController.GetTotalGames();
		
		switch (index) {
		case 0: {
			text = "Unlocked";
			canUse = true;
			break;
		}
		case 1: {
			text = "Tap 20 things to unlock";
			canUse = totalThings >= 20;
			if (!canUse) {
				text += " - " + (20 - totalThings) + " to go.";
			}
			break;
		}
		case 2: {
			text = "Tap 50 things to unlock";
			canUse = totalThings >= 50;
			if (!canUse) {
				text += " - " + (50 - totalThings) + " to go.";
			}
			break;
		}
		case 3: {
			text = "Play 20 games to unlock";
			canUse = totalGames >= 20;
			if (!canUse) {
				text += " - " + (20 - totalGames) + " to go.";
			}
			break;
		} 
		case 4: {
			text = "Play 20mins games to unlock";
			canUse = totalTime >= 1200;
			if (!canUse) {
				text += " - " + TimeFromSeconds(1200 - totalTime) + " to go.";
			}
			break;
		} 
		}
		
		descriptionText.text = text;
		useButton.interactable = canUse;
	}
	
	
	string TimeFromSeconds(int seconds) {
		System.TimeSpan time = System.TimeSpan.FromSeconds(seconds);
		return string.Format("{0:D2}m:{1:D2}s", time.Minutes, time.Seconds);
	}
}
