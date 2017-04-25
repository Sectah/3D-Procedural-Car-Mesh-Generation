using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombineMeshes : MonoBehaviour {

	void Start() {
		
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter> ();
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];

		int i = 0;
		while (i < meshFilters.Length) {
			combine [i].mesh = meshFilters [i].sharedMesh;
			combine [i].transform = meshFilters [i].transform.localToWorldMatrix;
			i++;
		}

		transform.GetComponent<MeshFilter> ().mesh = new Mesh ();
		transform.GetComponent<MeshFilter> ().mesh.CombineMeshes (combine);

		//Destroy all the children.
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
	}
}

