using UnityEngine;
using UnityEngine.UI;

public class Seed : MonoBehaviour {

	[Header("RANDOMISE THE SEED?")]
	public bool Randomise = true;

	[Header("SET YOUR OWN SEED (10 digits)")]
	public int seed = 0;

	void Awake () {

		seed = (Randomise) ? Mathf.Abs ((int)(System.DateTime.Now.Ticks)) : seed;

		Random.InitState (seed);
		FindObjectOfType<InputField> ().text = seed.ToString();
	}
}
