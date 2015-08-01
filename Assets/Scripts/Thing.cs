using UnityEngine;
using System.Collections;

public class Thing : MonoBehaviour {

	public float speed = 5f;
	public float deltaY = 0.8f;
	public bool alive = true;
	public bool visible = false;
	public bool scaped = false;
	public bool isBad = false;
	public bool visibleAtStart = false;
	
	float time = 0;
	bool goingUp = false;
	bool goingDown = false;
	float initY;
	float endY;
	Vector3 pos;
	
	SpriteRenderer imageRenderer;
	Transform imageTransform;

	public Sprite sprite;
	
	GameController controller;
	
	AudioSource audio;
	
	void Awake () {
		controller = FindObjectOfType<GameController> ();
		audio = GetComponent<AudioSource> ();
		pos = Vector2.zero;
		imageTransform = transform.FindChild("image");
		imageRenderer = imageTransform.GetComponent<SpriteRenderer> ();
	}

	void Start () {
		initY = imageTransform.position.y;
		endY = imageTransform.position.y + deltaY;
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
						Hide ();
						controller.HideThing(this);
					} else {
						scaped = true;
						
//						audio.clip = GameController.endGameClip;
//						audio.Play ();
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
		imageRenderer.sprite = sprite;
	}
	
	public void Up(bool bad, float visibleTime) {
		if (alive) {
			isBad = bad;
			if (isBad) {
				imageTransform.localScale = new Vector2(1, -1);
			} else {
				imageTransform.localScale = new Vector2(1, 1);
			}
			time = visibleTime;
		}
		goingUp = true;
		goingDown = false;
		visible = true;
	}
	
	public void Tap(AudioClip clip) {
		if (visible) {
			Hide ();
//			audio.clip = clip;
//			audio.Play ();
		}
	}
	
	void Hide() {
		visible = false;
		goingUp = false;
		goingDown = true;
	}
}
