using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class Thing : MonoBehaviour {
=======
[System.Serializable]
public class ThingsTheme
{
	public Sprite aliveSprite;
	public Sprite aliveBadSprite;
	public Sprite deadSprite;
}

public class Thing : MonoBehaviour
{
>>>>>>> f271585... Add git ignore

	public float speed = 5f;
	public float deltaY = 0.8f;
	public bool alive = true;
	public bool visible = false;
	public bool scaped = false;
	public bool isBad = false;
	
	float time = 0;
	bool goingUp = false;
	bool goingDown = false;
	float initY;
	float endY;
	Vector3 pos;
	
	SpriteRenderer imageRenderer;
	Transform imageTransform;
	
<<<<<<< HEAD
	public Sprite aliveSprite;
	public Sprite aliveBadSprite;
	public Sprite deadSprite;
	
	GameController controller;
	
	void Awake () {
		controller = FindObjectOfType<GameController> ();
		pos = Vector2.zero;
		imageTransform = transform.FindChild("image");
		imageRenderer = imageTransform.GetComponent<SpriteRenderer> ();
	}

	void Start () {
		initY = imageTransform.position.y;
		endY = imageTransform.position.y + deltaY;
		imageRenderer.sprite = aliveSprite;
	}
	
	void Update () {
		if (goingUp) {
			pos = imageTransform.position;
			pos.y = Mathf.MoveTowards(pos.y, endY, speed * Time.deltaTime);
			
			if (Mathf.Abs(pos.y - endY) < 0.01f) {
=======
	public ThingsTheme thingTheme;
	
	GameController controller;
	
	void Awake ()
	{
		controller = FindObjectOfType<GameController> ();
		pos = Vector2.zero;
		imageTransform = transform.FindChild ("image");
		imageRenderer = imageTransform.GetComponent<SpriteRenderer> ();
	}

	void Start ()
	{
		initY = imageTransform.position.y;
		endY = imageTransform.position.y + deltaY;
		imageRenderer.sprite = thingTheme.aliveSprite;
	}
	
	void Update ()
	{
		if (goingUp) {
			pos = imageTransform.position;
			pos.y = Mathf.MoveTowards (pos.y, endY, speed * Time.deltaTime);
			
			if (Mathf.Abs (pos.y - endY) < 0.01f) {
>>>>>>> f271585... Add git ignore
				pos.y = endY;
				goingUp = false;
			}
			
			imageTransform.position = pos;
		} else if (goingDown) {
			pos = imageTransform.position;
<<<<<<< HEAD
			pos.y = Mathf.MoveTowards(pos.y, initY, speed * Time.deltaTime);
			
			if (Mathf.Abs(pos.y - initY) < 0.01f) {
=======
			pos.y = Mathf.MoveTowards (pos.y, initY, speed * Time.deltaTime);
			
			if (Mathf.Abs (pos.y - initY) < 0.01f) {
>>>>>>> f271585... Add git ignore
				pos.y = initY;
				goingDown = false;
			}
		
			imageTransform.position = pos;
		} else {
			if (alive && visible) {
				time -= Time.deltaTime;
				if (time <= 0) {
					if (isBad) {
<<<<<<< HEAD
						Tap();
						controller.HideThing(this);
=======
						Tap ();
						controller.HideThing (this);
>>>>>>> f271585... Add git ignore
					} else {
						scaped = true;
					}
				}
			}
		}
	}
	
<<<<<<< HEAD
	public void Reset () {
=======
	public void Reset ()
	{
>>>>>>> f271585... Add git ignore
		visible = false;
		goingUp = false;
		goingDown = false;
		scaped = false;
		alive = true;
		pos = imageTransform.position;
		pos.y = initY;
		imageTransform.position = pos;
	}
	
<<<<<<< HEAD
	public void Up(bool bad, float visibleTime) {
		if (alive) {
			isBad = bad;
			if (isBad) {
				imageRenderer.sprite = aliveBadSprite;
			} else {
				imageRenderer.sprite = aliveSprite;
=======
	public void Up (bool bad, float visibleTime)
	{
		if (alive) {
			isBad = bad;
			if (isBad) {
				imageRenderer.sprite = thingTheme.aliveBadSprite;
			} else {
				imageRenderer.sprite = thingTheme.aliveSprite;
>>>>>>> f271585... Add git ignore
			}
			time = visibleTime;
		}
		goingUp = true;
		goingDown = false;
		visible = true;
	}
	
<<<<<<< HEAD
	public void Tap() {
=======
	public void Tap ()
	{
>>>>>>> f271585... Add git ignore
		if (visible) {
			visible = false;
			goingUp = false;
			goingDown = true;
		}
	}
	
<<<<<<< HEAD
	public void Kill() {
		alive = false;
		imageRenderer.sprite = deadSprite;
		Up(false, 0);
=======
	public void Kill ()
	{
		alive = false;
		imageRenderer.sprite = thingTheme.deadSprite;
		Up (false, 0);
>>>>>>> f271585... Add git ignore
	}
}
