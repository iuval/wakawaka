using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Rand = UnityEngine.Random;

<<<<<<< HEAD
public class GameController : MonoBehaviour {
=======
public class GameController : MonoBehaviour
{
>>>>>>> f271585... Add git ignore
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

<<<<<<< HEAD
	void Start () {
		topScore = PlayerPrefs.GetInt("top_score");
		menu.SetScore(score, topScore);
	}
	
	void Update () {
=======
	void Start ()
	{
		topScore = PlayerPrefs.GetInt ("top_score");
		menu.SetScore (score, topScore);
	}
	
	void Update ()
	{
>>>>>>> f271585... Add git ignore
		if (playing) {
			if (hiddenThings.Count > 0) {
				time -= Time.deltaTime;
				if (time <= 0) {
<<<<<<< HEAD
					ShowThing();
					time = Rand.Range(timeBetweenThings, timeBetweenThings * 1.1f);
=======
					ShowThing ();
					time = Rand.Range (timeBetweenThings, timeBetweenThings * 1.1f);
>>>>>>> f271585... Add git ignore
				}
			}
			
			CheckForInput ();
			
			foreach (Thing thing in things) {
				if (thing.alive && thing.scaped) {
					EndGame ();
				}
			}
			
			if (deadThings == 9) {
<<<<<<< HEAD
				EndGame();
=======
				EndGame ();
>>>>>>> f271585... Add git ignore
			}
		} else if (waitingForGame) {
			CheckForInput ();
		}
	}
	
<<<<<<< HEAD
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
=======
	void ShowThing ()
	{
		Thing thing = hiddenThings [Rand.Range (0, hiddenThings.Count - 1)];
		if (thing) {
			bool isBad = Rand.Range (0f, 1f) <= badThingChance;
			thing.Up (isBad, thingVisibleTime);
			hiddenThings.Remove (thing);
		}
	}
	
	void CheckForInput ()
	{
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
			foreach (Touch touch in Input.touches) {
				if (touch.phase.Equals (TouchPhase.Began)) {	
					for (int j = 0; j < colliders.Length; ++j) {
						Vector3 pos = Camera.main.ScreenToWorldPoint (touch.position);
						if (colliders [j].OverlapPoint (pos)) {
							TapThing (colliders [j].GetComponent<Thing> ());
>>>>>>> f271585... Add git ignore
						}
					}
				}
			}
		} else {
<<<<<<< HEAD
			if (Input.GetMouseButtonDown(0)) {
				for (int j = 0; j < colliders.Length; ++j) {
					Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					if (colliders[j].OverlapPoint(pos)) {
						TapThing(colliders[j].GetComponent<Thing>());
=======
			if (Input.GetMouseButtonDown (0)) {
				for (int j = 0; j < colliders.Length; ++j) {
					Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					if (colliders [j].OverlapPoint (pos)) {
						TapThing (colliders [j].GetComponent<Thing> ());
>>>>>>> f271585... Add git ignore
					}
				}
			}
		}
	}
	
<<<<<<< HEAD
	void TapThing (Thing thing) {
		if (thing.alive) {
			if (thing.visible && !thing.isBad) {
				thing.Tap();
				hiddenThings.Add(thing);
=======
	void TapThing (Thing thing)
	{
		if (thing.alive) {
			if (thing.visible && !thing.isBad) {
				thing.Tap ();
				hiddenThings.Add (thing);
>>>>>>> f271585... Add git ignore
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
<<<<<<< HEAD
					thing.Kill();
=======
					thing.Kill ();
>>>>>>> f271585... Add git ignore
					deadThings ++;
					timeBetweenThings *= 0.8f;
					thingVisibleTime *= 0.9f;
				}
			}
		}
	}
	
<<<<<<< HEAD
	void ResetGame () {
=======
	void ResetGame ()
	{
>>>>>>> f271585... Add git ignore
		timeBetweenThings = startTimeBetweenThings;
		thingVisibleTime = startThingVisibleTime;
		playing = false;
		waitingForGame = false;
		deadThings = 0;
		hiddenThings = new List<Thing> ();
		colliders = new CircleCollider2D[things.Length];
		
<<<<<<< HEAD
		int currentIndex = GetSkinIndex();
		for (int i = 0; i < things.Length; i++) {
			Thing thing = things[i];
			thing.Reset ();
			colliders[i] = thing.GetComponent<CircleCollider2D> ();
			hiddenThings.Add(thing);
			thing.aliveSprite = thingSprites[currentIndex];
=======
		int currentIndex = GetSkinIndex ();
		for (int i = 0; i < things.Length; i++) {
			Thing thing = things [i];
			thing.Reset ();
			colliders [i] = thing.GetComponent<CircleCollider2D> ();
			hiddenThings.Add (thing);
			thing.thingTheme.aliveSprite = thingSprites [currentIndex];
>>>>>>> f271585... Add git ignore
		}
		
		time = 0;
	}
	
<<<<<<< HEAD
	public void NewGame() {
=======
	public void NewGame ()
	{
>>>>>>> f271585... Add git ignore
		score = 0;
		scoreText.text = score + "";
		ResetGame ();
		menu.Hide ();
		playing = false;
		waitingForGame = true;

<<<<<<< HEAD
		things[4].Up(false, 10f);
	}
	
	public void EndGame() {
=======
		things [4].Up (false, 10f);
	}
	
	public void EndGame ()
	{
>>>>>>> f271585... Add git ignore
		playing = false;
		
		if (score > topScore) {
			topScore = score;
<<<<<<< HEAD
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
=======
			SetTopScore (topScore);
		}
		AddTotalTaps (score);
		AddTotalGames (1);
		AddTotalTime ((int)(Time.time - startTime));
		
		menu.SetScore (score, topScore);
		menu.gameObject.SetActive (true);
		menu.Show ();
	}
	
	public void HideThing (Thing thing)
	{
		hiddenThings.Add (thing);
>>>>>>> f271585... Add git ignore
	}
	
	// Prefs
	
<<<<<<< HEAD
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
=======
	public static int GetTotalTaps ()
	{
		return GetIntPref ("total_taps");
	}
	
	public static void AddTotalTaps (int amount)
	{
		AddIntPref ("total_taps", amount);
	}
	
	public static int GetTotalTime ()
	{
		return GetIntPref ("total_time");
	}
	
	public static void AddTotalTime (int amount)
	{
		AddIntPref ("total_time", amount);
	}
	
	public static int GetTotalGames ()
	{
		return GetIntPref ("total_games");
	}
	
	public static void AddTotalGames (int amount)
	{
		AddIntPref ("total_games", amount);
	}
		
	public static int GetTopScore ()
	{
		return GetIntPref ("top_score");
	}
	
	public static void SetTopScore (int amount)
	{
		SetIntPref ("top_score", amount);
	}

	public static int GetSkinIndex ()
	{
		return GetIntPref ("skin_index");
	}
	
	public static void SetSkinIndex (int index)
	{
		SetIntPref ("skin_index", index);
>>>>>>> f271585... Add git ignore
	}

	// Shared Prefs
	
<<<<<<< HEAD
	public static void SetIntPref(string name, int amount) {
		PlayerPrefs.SetInt(name, amount);
	}
	
	public static int GetIntPref(string name) {
		return PlayerPrefs.GetInt(name);
	}
	
	public static void AddIntPref(string name, int amount) {
		PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name) + amount);
=======
	public static void SetIntPref (string name, int amount)
	{
		PlayerPrefs.SetInt (name, amount);
	}
	
	public static int GetIntPref (string name)
	{
		return PlayerPrefs.GetInt (name);
	}
	
	public static void AddIntPref (string name, int amount)
	{
		PlayerPrefs.SetInt (name, PlayerPrefs.GetInt (name) + amount);
>>>>>>> f271585... Add git ignore
	}
}
