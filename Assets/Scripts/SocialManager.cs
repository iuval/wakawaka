using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void LogCallback(FBResult response) {
		Debug.Log(response.Text);
	}
	
	public void InitFBDelegate() {
		FB.Feed(
			link: "https://www.youtube.com/watch?v=oavMtUWDBTM",
			linkName: "WakaWaka",
			linkCaption: "Best game since la 'Arrimadia'",
			linkDescription: "4 out of 3 humans play this game when forced to.",
			picture: "http://upload.wikimedia.org/wikipedia/en/c/c5/Shakira_Waka_Waka_Video_2010.jpg",
			callback: LogCallback
			);
	}
	
	public void HideUnityDelegate(bool isUnityShown) {
		
	}
	
	public void ShareOnFacebook() {
		FB.Init(InitFBDelegate, HideUnityDelegate);
	} 
	
	public void ShareToTwitter () {
		Application.OpenURL("http://twitter.com/intent/tweet" +
		                    "?text=" + "Best game since la 'Arrimadia'" +
		                    "&amp;lang=en");
	}
	
}
