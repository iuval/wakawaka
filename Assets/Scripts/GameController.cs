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
	
	public Sprite[] thingSprites;
	
	List<Thing> hiddenThings;

	float startTime;
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
		menu.Show();
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
			
			Thing thing;
			for (int i = 0; i < things.Length; i ++) {
				thing = things[i];
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
			Touch touch;
			Touch[] touches = Input.touches;
			for (int i = 0; i < touches.Length; ++i) {
				touch = touches[i];
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
					startTime = Time.time;
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
		hiddenThings = new List<Thing> ();
		colliders = new CircleCollider2D[things.Length];
		
		int currentIndex = GetSkinIndex();
		for (int i = 0; i < things.Length; i++) {
			Thing thing = things[i];
			thing.Reset ();
			colliders[i] = thing.GetComponent<CircleCollider2D> ();
			hiddenThings.Add(thing);
			thing.thingsTheme.aliveSprite = thingSprites[currentIndex];
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
			SetTopScore(topScore);
		}
		AddTotalTaps(score);
		AddTotalGames(1);
		AddTotalTime((int)(Time.time - startTime));
		
		menu.SetScore(score, topScore);
		menu.gameObject.SetActive(true);
		menu.Show();
	}
	
	public void HideThing(Thing thing) {
		hiddenThings.Add(thing);
	}
	
	// Prefs
	
	public static int GetTotalTaps() {
		return GetIntPref("total_taps");
	}
	
	public static void AddTotalTaps(int amount) {
		AddIntPref("total_taps", amount);
	}
	
	public static int GetTotalTime() {
		return GetIntPref("total_time");
	}
	
	public static void AddTotalTime(int amount) {
		AddIntPref("total_time", amount);
	}
	
	public static int GetTotalGames() {
		return GetIntPref("total_games");
	}
	
	public static void AddTotalGames(int amount) {
		AddIntPref("total_games", amount);
	}
		
	public static int GetTopScore() {
		return GetIntPref("top_score");
	}
	
	public static void SetTopScore(int amount) {
		SetIntPref("top_score", amount);
	}

	public static int GetSkinIndex() {
		return GetIntPref("skin_index");
	}
	
	public static void SetSkinIndex(int index) {
		SetIntPref("skin_index", index);
	}

	// Shared Prefs
	
	public static void SetIntPref(string name, int amount) {
		PlayerPrefs.SetInt(name, amount);
	}
	
	public static int GetIntPref(string name) {
		return PlayerPrefs.GetInt(name);
	}
	
	public static void AddIntPref(string name, int amount) {
		PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name) + amount);
	}
}
