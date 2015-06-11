using UnityEngine;
using System.Collections;

[System.Serializable]
public class ThingsTheme : System.Object
{
	public Sprite aliveSprite;
	public Sprite aliveBadSprite;
	public Sprite deadSprite;
}

public class Thing : MonoBehaviour {

	public float speed = 5f;
	public float deltaY = 0.8f;
	public bool alive = true;
	public bool visible = false;
	public bool scaped = false;
	public bool isBad = false;
	public ThingsTheme thingsTheme;
	
	float time = 0;
	bool goingUp = false;
	bool goingDown = false;
	float initY;
	float endY;
	Vector3 pos;
	
	SpriteRenderer imageRenderer;
	Transform imageTransform;
	
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
		imageRenderer.sprite = thingTheme.aliveSprite;
	}
	
	void Update () {
		if (goingUp) {
			pos = imageTransform.position;
			pos.y = Mathf.MoveTowards(pos.y, endY, speed * Time.deltaTime);
			
			if (Mathf.Abs(pos.y - endY) < 0.01f) {
				pos.y = endY;
				goingUp = false;
			}
			
			imageTransform.position = pos;
		} else if (goingDown) {
			pos = imageTransform.position;
			pos.y = Mathf.MoveTowards(pos.y, initY, speed * Time.deltaTime);
			
			if (Mathf.Abs(pos.y - initY) < 0.01f) {
				pos.y = initY;
				goingDown = false;
			}
		
			imageTransform.position = pos;
		} else {
			if (alive && visible) {
				time -= Time.deltaTime;
				if (time <= 0) {
					if (isBad) {
						Tap();
						controller.HideThing(this);
					} else {
						scaped = true;
					}
				}
			}
		}
	}
	
	public void Reset () {
		visible = false;
		goingUp = false;
		goingDown = false;
		scaped = false;
		alive = true;
		pos = imageTransform.position;
		pos.y = initY;
		imageTransform.position = pos;
	}
	
	public void Up(bool bad, float visibleTime) {
		if (alive) {
			isBad = bad;
			if (isBad) {
				imageRenderer.sprite = thingTheme.aliveBadSprite;
			} else {
				imageRenderer.sprite = thingTheme.aliveSprite;
			}
			time = visibleTime;
		}
		goingUp = true;
		goingDown = false;
		visible = true;
	}
	
	public void Tap() {
		if (visible) {
			visible = false;
			goingUp = false;
			goingDown = true;
		}
	}
	
	public void Kill() {
		alive = false;
		imageRenderer.sprite = thingTheme.deadSprite;
		Up(false, 0);
	}
}
