using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class Timer : MonoBehaviour {

	Stopwatch sw = new Stopwatch ();

	void Awake () {
		sw.Start ();
	}

	// Use this for initialization
	void Start () {
		sw.Stop ();
		UnityEngine.Debug.Log (sw.ElapsedMilliseconds + "ms");

		File.AppendAllText ("Log.txt", sw.ElapsedMilliseconds + "\n");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
