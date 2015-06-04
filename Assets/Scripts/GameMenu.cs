using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameMenu : MonoBehaviour
{

	Animator anim;
	public Text scoreText;
	public Text topScoreText;
	public StoreMenu store;

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
		scoreText.text = "Score: " + score;
		topScoreText.text = "Top Score: " + topScore;
	}
	
	public void ShowStore ()
	{
		Hide ();
		store.Show ();
	}
}
