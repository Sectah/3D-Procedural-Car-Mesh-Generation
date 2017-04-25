using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel2 : MonoBehaviour {

	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;

	//Just for debugging purposes
	[Header("DELAY AND POSITIONAL DATA")]
	public float delay;
	public float radius;
	public float wheelPos;
	public float height;
	public int sides;

	void Start () {

		//Create a mesh filter while also assigning it as a variable to get the mesh property
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter> ();

		//Create a mesh renderer so we can actually display the mesh
		gameObject.AddComponent<MeshRenderer> ();

		//Set the mesh object to be that of the mesh from the mesh filter
		mesh = meshFilter.mesh;

		//Set a random material
		Object[] loadedMaterials = Resources.LoadAll("Materials");
		gameObject.GetComponent<Renderer> ().material = (Material)loadedMaterials [loadedMaterials.Length - 2];

		//Create the delay for the ienumerator
		delay = 0f;

		//Start the IEnumerator which will call create mesh after a small delay
		StartCoroutine (WaitForPreviousMesh());
	}

	public void CreateBasicMesh () {

		SidePanel1 panelScript = GameObject.Find("SidePanel1").GetComponent<SidePanel1> ();
		Wheel0 wheelScript = GameObject.Find("Wheel0").GetComponent<Wheel0> ();

		radius = wheelScript.radius;
		height = wheelScript.height;
		sides = wheelScript.sides;

		#region Vertices
		int nbVerticesCap = sides + 1;

		// bottom + top + sides
		Vector3[] vertices = new Vector3[nbVerticesCap + nbVerticesCap + sides * 2 + 2];
		int vert = 0;
		float twoPi = Mathf.PI * 2f;

		// Bottom cap
		vertices [vert++] = new Vector3 (0f, 0f, 0f);
		while (vert <= sides) {
			float rad = (float)vert / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, 0f, Mathf.Sin (rad) * radius);
			vert++;
		}

		// Top cap
		vertices [vert++] = new Vector3 (0f, height, 0f);
		while (vert <= sides * 2 + 1) {
			float rad = (float)(vert - sides - 1) / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, height, Mathf.Sin (rad) * radius);
			vert++;
		}

		// Sides
		int v = 0;
		while (vert <= vertices.Length - 4) {
			float rad = (float)v / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, height, Mathf.Sin (rad) * radius);
			vertices [vert + 1] = new Vector3 (Mathf.Cos (rad) * radius, 0, Mathf.Sin (rad) * radius);
			vert += 2;
			v++;
		}
		vertices [vert] = vertices [sides * 2 + 2];
		vertices [vert + 1] = vertices [sides * 2 + 3];
		#endregion

		#region Triangles
		int nbTriangles = sides + sides + sides * 2;
		int[] triangles = new int[nbTriangles * 3 + 3];

		// Bottom cap
		int tri = 0;
		int i = 0;
		while (tri < sides - 1) {
			triangles [i] = 0;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = tri + 2;
			tri++;
			i += 3;
		}
		triangles [i] = 0;
		triangles [i + 1] = tri + 1;
		triangles [i + 2] = 1;
		tri++;
		i += 3;

		// Top cap
		//tri++;
		while (tri < sides * 2) {
			triangles [i] = tri + 2;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = nbVerticesCap;
			tri++;
			i += 3;
		}

		triangles [i] = nbVerticesCap + 1;
		triangles [i + 1] = tri + 1;
		triangles [i + 2] = nbVerticesCap;		
		tri++;
		i += 3;
		tri++;

		// Sides
		while (tri <= nbTriangles) {
			triangles [i] = tri + 2;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = tri + 0;
			tri++;
			i += 3;

			triangles [i] = tri + 1;
			triangles [i + 1] = tri + 2;
			triangles [i + 2] = tri + 0;
			tri++;
			i += 3;
		}
		#endregion

		mesh.vertices = vertices;
		mesh.triangles = triangles;

		wheelPos = wheelScript.wheelPos;
		float zPos = Vector3.Lerp(panelScript.mesh.vertices[1], panelScript.mesh.vertices[6], wheelPos).z;
		gameObject.transform.position = new Vector3(panelScript.mesh.vertices[0].x - 0.1f, 0, zPos);
		gameObject.transform.rotation = Quaternion.Euler (0, 0, -90.0f);

		mesh.RecalculateNormals ();
	}

	public void CreateClassicMesh () {

		ClassicSidePanel1 panelScript = GameObject.Find("ClassicSidePanel1").GetComponent<ClassicSidePanel1> ();
		Wheel0 wheelScript = GameObject.Find("Wheel0").GetComponent<Wheel0> ();

		radius = wheelScript.radius;
		height = wheelScript.height;
		sides = wheelScript.sides;

		#region Vertices
		int nbVerticesCap = sides + 1;

		// bottom + top + sides
		Vector3[] vertices = new Vector3[nbVerticesCap + nbVerticesCap + sides * 2 + 2];
		int vert = 0;
		float twoPi = Mathf.PI * 2f;

		// Bottom cap
		vertices [vert++] = new Vector3 (0f, 0f, 0f);
		while (vert <= sides) {
			float rad = (float)vert / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, 0f, Mathf.Sin (rad) * radius);
			vert++;
		}

		// Top cap
		vertices [vert++] = new Vector3 (0f, height, 0f);
		while (vert <= sides * 2 + 1) {
			float rad = (float)(vert - sides - 1) / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, height, Mathf.Sin (rad) * radius);
			vert++;
		}

		// Sides
		int v = 0;
		while (vert <= vertices.Length - 4) {
			float rad = (float)v / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, height, Mathf.Sin (rad) * radius);
			vertices [vert + 1] = new Vector3 (Mathf.Cos (rad) * radius, 0, Mathf.Sin (rad) * radius);
			vert += 2;
			v++;
		}
		vertices [vert] = vertices [sides * 2 + 2];
		vertices [vert + 1] = vertices [sides * 2 + 3];
		#endregion

		#region Triangles
		int nbTriangles = sides + sides + sides * 2;
		int[] triangles = new int[nbTriangles * 3 + 3];

		// Bottom cap
		int tri = 0;
		int i = 0;
		while (tri < sides - 1) {
			triangles [i] = 0;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = tri + 2;
			tri++;
			i += 3;
		}
		triangles [i] = 0;
		triangles [i + 1] = tri + 1;
		triangles [i + 2] = 1;
		tri++;
		i += 3;

		// Top cap
		//tri++;
		while (tri < sides * 2) {
			triangles [i] = tri + 2;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = nbVerticesCap;
			tri++;
			i += 3;
		}

		triangles [i] = nbVerticesCap + 1;
		triangles [i + 1] = tri + 1;
		triangles [i + 2] = nbVerticesCap;		
		tri++;
		i += 3;
		tri++;

		// Sides
		while (tri <= nbTriangles) {
			triangles [i] = tri + 2;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = tri + 0;
			tri++;
			i += 3;

			triangles [i] = tri + 1;
			triangles [i + 1] = tri + 2;
			triangles [i + 2] = tri + 0;
			tri++;
			i += 3;
		}
		#endregion

		mesh.vertices = vertices;
		mesh.triangles = triangles;

		wheelPos = wheelScript.wheelPos;
		float zPos = Vector3.Lerp(panelScript.mesh.vertices[1], panelScript.mesh.vertices[7], wheelPos).z;
		gameObject.transform.position = new Vector3(panelScript.mesh.vertices[0].x - 0.1f, 0, zPos);
		gameObject.transform.rotation = Quaternion.Euler (0, 0, -90.0f);

		mesh.RecalculateNormals ();
	}

	public void CreateVanMesh () {

		VanSidePanel1 panelScript = GameObject.Find("VanSidePanel1").GetComponent<VanSidePanel1> ();
		Wheel0 wheelScript = GameObject.Find("Wheel0").GetComponent<Wheel0> ();

		radius = wheelScript.radius;
		height = wheelScript.height;
		sides = wheelScript.sides;

		#region Vertices
		int nbVerticesCap = sides + 1;

		// bottom + top + sides
		Vector3[] vertices = new Vector3[nbVerticesCap + nbVerticesCap + sides * 2 + 2];
		int vert = 0;
		float twoPi = Mathf.PI * 2f;

		// Bottom cap
		vertices [vert++] = new Vector3 (0f, 0f, 0f);
		while (vert <= sides) {
			float rad = (float)vert / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, 0f, Mathf.Sin (rad) * radius);
			vert++;
		}

		// Top cap
		vertices [vert++] = new Vector3 (0f, height, 0f);
		while (vert <= sides * 2 + 1) {
			float rad = (float)(vert - sides - 1) / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, height, Mathf.Sin (rad) * radius);
			vert++;
		}

		// Sides
		int v = 0;
		while (vert <= vertices.Length - 4) {
			float rad = (float)v / sides * twoPi;
			vertices [vert] = new Vector3 (Mathf.Cos (rad) * radius, height, Mathf.Sin (rad) * radius);
			vertices [vert + 1] = new Vector3 (Mathf.Cos (rad) * radius, 0, Mathf.Sin (rad) * radius);
			vert += 2;
			v++;
		}
		vertices [vert] = vertices [sides * 2 + 2];
		vertices [vert + 1] = vertices [sides * 2 + 3];
		#endregion

		#region Triangles
		int nbTriangles = sides + sides + sides * 2;
		int[] triangles = new int[nbTriangles * 3 + 3];

		// Bottom cap
		int tri = 0;
		int i = 0;
		while (tri < sides - 1) {
			triangles [i] = 0;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = tri + 2;
			tri++;
			i += 3;
		}
		triangles [i] = 0;
		triangles [i + 1] = tri + 1;
		triangles [i + 2] = 1;
		tri++;
		i += 3;

		// Top cap
		//tri++;
		while (tri < sides * 2) {
			triangles [i] = tri + 2;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = nbVerticesCap;
			tri++;
			i += 3;
		}

		triangles [i] = nbVerticesCap + 1;
		triangles [i + 1] = tri + 1;
		triangles [i + 2] = nbVerticesCap;		
		tri++;
		i += 3;
		tri++;

		// Sides
		while (tri <= nbTriangles) {
			triangles [i] = tri + 2;
			triangles [i + 1] = tri + 1;
			triangles [i + 2] = tri + 0;
			tri++;
			i += 3;

			triangles [i] = tri + 1;
			triangles [i + 1] = tri + 2;
			triangles [i + 2] = tri + 0;
			tri++;
			i += 3;
		}
		#endregion

		mesh.vertices = vertices;
		mesh.triangles = triangles;

		wheelPos = wheelScript.wheelPos;
		float zPos = Vector3.Lerp(panelScript.mesh.vertices[4], panelScript.mesh.vertices[8], wheelPos).z;
		gameObject.transform.position = new Vector3(panelScript.mesh.vertices[0].x - 0.1f, 0, zPos);
		gameObject.transform.rotation = Quaternion.Euler (0, 0, -90.0f);

		mesh.RecalculateNormals ();
	}

	IEnumerator WaitForPreviousMesh() {

		yield return new WaitForSeconds (delay);

		if (GameObject.FindObjectOfType<CreateCar> ().model == CreateCar.Model.Basic) {

			CreateBasicMesh ();

		} else if (GameObject.FindObjectOfType<CreateCar> ().model == CreateCar.Model.Classic) {

			CreateClassicMesh ();

		} else if (GameObject.FindObjectOfType<CreateCar> ().model == CreateCar.Model.Van) {

			CreateVanMesh ();
		}
	}
}
