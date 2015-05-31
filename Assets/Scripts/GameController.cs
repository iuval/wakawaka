using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Rand = UnityEngine.Random;

public class GameController : MonoBehaviour {
	public static RuntimePlatform platform = Application.platform;

	public GameMenu menu;
	public Text scoreText;

	public Thing[] things;
	CircleCollider2D[] colliders;
	List<int> thingsToKill;
	
	List<Thing> hiddenThings;

	float time;
	float startTimeBetweenThings = 1f;
	public float timeBetweenThings = 1f;
	float startThingVisibleTime = 1f;
	float thingVisibleTime = 1f;
	float badThingChance = .2f;
	
	bool waitingForGame = false;
	bool playing = false;
	
	int deadThings = 0;
	int topScore = 0;
	int score = 0;

	void Start () {
		topScore = PlayerPrefs.GetInt("top_score");
		menu.SetScore(score, topScore);
	}
	
	void Update () {
		if (playing) {
			if (hiddenThings.Count > 0) {
				time -= Time.deltaTime;
				if (time <= 0) {
					ShowThing();
					time = Rand.Range(timeBetweenThings, timeBetweenThings * 1.1f);
				}
			}
			
			CheckForInput ();
			
			foreach (Thing thing in things) {
				if (thing.alive && thing.scaped) {
					EndGame ();
				}
			}
			
			if (deadThings == 9) {
				EndGame();
			}
		} else if (waitingForGame) {
			CheckForInput ();
		}
	}
	
	void ShowThing () {
		Thing thing = hiddenThings[Rand.Range(0, hiddenThings.Count - 1)];
		if (thing) {
			bool isBad = Rand.Range(0f, 1f) <= badThingChance;
			thing.Up (isBad, thingVisibleTime);
			hiddenThings.Remove(thing);
		}
	}
	
	void CheckForInput () {
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
			foreach (Touch touch in Input.touches) {
				if (touch.phase.Equals(TouchPhase.Began)) {	
					for (int j = 0; j < colliders.Length; ++j) {
						Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
						if (colliders[j].OverlapPoint(pos)) {
							TapThing(colliders[j].GetComponent<Thing>());
						}
					}
				}
			}
		} else {
			if (Input.GetMouseButtonDown(0)) {
				for (int j = 0; j < colliders.Length; ++j) {
					Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					if (colliders[j].OverlapPoint(pos)) {
						TapThing(colliders[j].GetComponent<Thing>());
					}
				}
			}
		}
	}
	
	void TapThing (Thing thing) {
		if (thing.alive) {
			if (thing.visible && !thing.isBad) {
				thing.Tap();
				hiddenThings.Add(thing);
				score += 1;
				scoreText.text = score + "";
				
				if (waitingForGame) {
					waitingForGame = false;
					playing = true;
				}
				
				timeBetweenThings *= 0.9999f;
			} else {
				if (playing) {
					thing.Kill();
					deadThings ++;
					timeBetweenThings *= 0.8f;
					thingVisibleTime *= 0.9f;
				}
			}
		}
	}
	
	void ResetGame () {
		timeBetweenThings = startTimeBetweenThings;
		thingVisibleTime = startThingVisibleTime;
		playing = false;
		waitingForGame = false;
		deadThings = 0;
		thingsToKill = new List<int> ();
		hiddenThings = new List<Thing> ();
		colliders = new CircleCollider2D[things.Length];
		for (int i = 0; i < things.Length; i++) {
			Thing thing = things[i];
			thing.Reset ();
			colliders[i] = thing.GetComponent<CircleCollider2D> ();
			hiddenThings.Add(thing);
		}
		
		time = 0;
	}
	
	public void NewGame() {
		score = 0;
		scoreText.text = score + "";
		ResetGame ();
		menu.Hide ();
		playing = false;
		waitingForGame = true;

		things[4].Up(false, 10f);
	}
	
	public void EndGame() {
		playing = false;
		
		if (score > topScore) {
			topScore = score;
			PlayerPrefs.SetInt("top_score", topScore);
		}
		menu.SetScore(score, topScore);
		menu.gameObject.SetActive(true);
		menu.Show();
	}
	
	public void HideThing(Thing thing) {
		hiddenThings.Add(thing);
	}
}
