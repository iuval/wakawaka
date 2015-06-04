using UnityEngine;
using System.Collections;
using UnityEngine.UI;

<<<<<<< HEAD
public class GameMenu : MonoBehaviour {
=======
[ExecuteInEditMode]
public class GameMenu : MonoBehaviour
{
>>>>>>> f271585... Add git ignore

	Animator anim;
	public Text scoreText;
	public Text topScoreText;
	public StoreMenu store;

<<<<<<< HEAD
	void Awake () {
		anim = GetComponentInChildren<Animator> ();
	}
			
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Show() {
		gameObject.SetActive(true);
		anim.SetTrigger("show");
	}
	
	public void Hide() {
		anim.SetTrigger("hide");
	}
	
	void Hidden() {
		gameObject.SetActive(false);
	}
	
	public void SetScore(int score, int topScore) {
=======
	void Awake ()
	{
		anim = GetComponentInChildren<Animator> ();
	}
			
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void Show ()
	{
		gameObject.SetActive (true);
		anim.SetTrigger ("show");
	}
	
	public void Hide ()
	{
		anim.SetTrigger ("hide");
	}
	
	void Hidden ()
	{
		gameObject.SetActive (false);
	}
	
	public void SetScore (int score, int topScore)
	{
>>>>>>> f271585... Add git ignore
		scoreText.text = "Score: " + score;
		topScoreText.text = "Top Score: " + topScore;
	}
	
<<<<<<< HEAD
	public void ShowStore() {
		Hide();
		store.Show();
=======
	public void ShowStore ()
	{
		Hide ();
		store.Show ();
>>>>>>> f271585... Add git ignore
	}
}
