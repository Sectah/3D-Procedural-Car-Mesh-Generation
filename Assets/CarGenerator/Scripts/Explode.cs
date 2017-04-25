using UnityEngine;

public class Explode : MonoBehaviour {

	int children;
	Vector3 forward;

	public float travelTime;
	public float timer;

	public bool popOut;

	Vector3[] ogPos;

	void Start () {

		if (gameObject.name == "Wheels") {

			children = transform.childCount;

			ogPos = new Vector3[children];

			for (int i = 0; i < children; i++) {
				
				ogPos [i] = transform.GetChild (i).transform.position;
			}
		}
	}

	void Update () {

		children = transform.childCount;

		timer += Time.deltaTime;

		if (popOut) {
			Out ();
		} else {
			In ();
		}
	}
		
	public void Out () {

		for (int i = 0; i < children; i++) {

			Vector3 forward = transform.GetChild (i).transform.TransformDirection (transform.GetChild (i).GetComponent<MeshFilter> ().mesh.normals [0]);

			if (gameObject.name == "Windows") {

				transform.GetChild (i).transform.position = Vector3.Lerp (transform.GetChild (i).transform.position, forward * 6, timer / travelTime);

			} else if (gameObject.name == "Wheels") {

				transform.GetChild (i / 2).transform.position = Vector3.Lerp (transform.GetChild (i / 2).transform.position, (ogPos [i / 2] + Vector3.right * 4) + Vector3.down * 2, timer / travelTime);
				transform.GetChild ((i / 2) + 2).transform.position = Vector3.Lerp (transform.GetChild ((i / 2) + 2).transform.position, (ogPos [(i / 2) + 2] + Vector3.left * 4) + Vector3.down * 2, timer / travelTime);

			} else {

				if (transform.GetChild(i).transform.name.Contains("SideWindow")) {

					if (transform.GetChild (i).transform.name.Contains ("0") || transform.GetChild (i).transform.name.Contains ("2")) {
						
						transform.GetChild (i).transform.position = Vector3.Lerp (transform.GetChild (i).transform.position, forward * 5, timer / travelTime);

					} else {
						
						transform.GetChild (i).transform.position = Vector3.Lerp (transform.GetChild (i).transform.position, forward * 4, timer / travelTime);
					}
				}

				transform.GetChild (i).transform.position = Vector3.Lerp (transform.GetChild (i).transform.position, forward * 3, timer / travelTime);
			}
		}
	}

	public void In () {

		for (int i = 0; i < children; i++) {

			if (gameObject.name == "Wheels") {

				transform.GetChild (i).transform.position = Vector3.Lerp (transform.GetChild (i).transform.position, ogPos [i], timer / travelTime);

			} else {

				transform.GetChild (i).transform.position = Vector3.Lerp (transform.GetChild (i).transform.position, Vector3.zero, timer / travelTime);
			}
		}
	}
}
