using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.IO;

public class RaceTrack : MonoBehaviour {
	int counter = 0;
	string line;
	public float explosionRadius = 30.0F;
	float new_x;
	float new_y;
	float new_z;

	// Use this for initialization
	void Start () {
		//Read the file and display it line by line
		System.IO.StreamReader file = new System.IO.StreamReader ("C:/Users/Sam/Documents/GitHub/Air-Race/Assets/race2.txt");
		while ((line = file.ReadLine ()) != null) {
			Console.WriteLine (line);
			string[] bits = line.Split(' ');
			new_x = float.Parse (bits[0]);
			new_y = float.Parse (bits[1]);
			new_z = float.Parse (bits[2]);
			transform.position.Set (new_x, new_y, new_z);
			//Gizmos.DrawWireSphere (transform.position, explosionRadius);
			counter++;
		}
		file.Close ();
		Console.ReadLine();
	}

	// Update is called once per frame
	void Update () {
		
	}
}

