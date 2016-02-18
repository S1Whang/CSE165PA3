using UnityEngine;
using System.Collections;

public class TextScript : MonoBehaviour {
	double time;
	TextMesh tm;
	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time < 1.0f)
			tm.text = "3";
		else if (time < 2.0f)
			tm.text = "2";
		else if (time < 3.0f)
			tm.text = "1";
		else if (time < 4.0f)
			tm.text = "GO!";
		else
			tm.text = ((double)(time-3)).ToString("F2");
	}
}
