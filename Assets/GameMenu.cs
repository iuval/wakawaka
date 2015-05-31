using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

	Animator anim;
	public Text scoreText;
	public Text topScoreText;

	void Awake () {
		anim = GetComponentInChildren<Animator> ();
	}
			
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Show() {
		anim.SetTrigger("show");
	}
	
	public void Hide() {
		anim.SetTrigger("hide");
	}
	
	void Hidden() {
		gameObject.SetActive(false);
	}
	
	public void SetScore(int score, int topScore) {
		scoreText.text = "Score: " + score;
		topScoreText.text = "Top Score: " + topScore;
	}
}
