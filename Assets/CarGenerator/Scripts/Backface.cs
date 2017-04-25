using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backface : MonoBehaviour {

	// Use this for initialization
	private void Start () {
		
		Mesh mesh = GetComponent<MeshFilter> ().mesh;

		Vector3[] vertices = mesh.vertices;
		int szV = vertices.Length;
		Vector3[] newVerts = new Vector3[szV * 2];

		for (int j = 0; j < szV; j++) {
			
			//Duplicate vertices and uvs:
			newVerts [j] = newVerts [j + szV] = vertices [j];
		}

		int[] triangles = mesh.triangles;
		int szT = triangles.Length;
		int[] newTris = new int[szT * 2]; //Double the triangles

		for (int i = 0; i < szT; i += 3) {
			
			//Copy the original triangle
			newTris [i] = triangles [i];
			newTris [i + 1] = triangles [i + 1];
			newTris [i + 2] = triangles [i + 2];

			//Save the new reversed triangle
			int j = i + szT; 

			newTris [j] = triangles [i] + szV;
			newTris [j + 2] = triangles [i + 1] + szV;
			newTris [j + 1] = triangles [i + 2] + szV;
		}

		mesh.vertices = newVerts;
		mesh.triangles = newTris;
		mesh.RecalculateNormals();
	}
}
