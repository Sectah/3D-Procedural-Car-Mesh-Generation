using System.Collections;
using UnityEngine;

public class Underside : MonoBehaviour {

	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;

	//All the scripts I need to connect the windows to the side of the mesh
	CarGenerator0Grill grillScript;
	SidePanel0 sidePanel0Script;
	SidePanel1 sidePanel1Script;

	void Start () {

		//Create a mesh filter while also assigning it as a variable to get the mesh property
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter> ();

		//Create a mesh renderer so we can actually display the mesh
		gameObject.AddComponent<MeshRenderer> ();

		//Set the mesh object to be that of the mesh from the mesh filter
		mesh = meshFilter.mesh;

		//Set a random material
		Object[] loadedMaterials = Resources.LoadAll("Materials");
		gameObject.GetComponent<Renderer> ().material = (Material)loadedMaterials [Random.Range (0, loadedMaterials.Length - 2)];

		//Get the scripts
		grillScript = FindObjectOfType<CarGenerator0Grill> ();
		sidePanel0Script = FindObjectOfType<SidePanel0> ();
		sidePanel1Script = FindObjectOfType<SidePanel1> ();

		//Call the create mesh function
		CreateMesh ();
	}
	
	void CreateMesh () {

		//Getting all the positional data from previous meshes
		Vector3 grill0 = grillScript.mesh.vertices [0]; 
		Vector3 grill1 = grillScript.mesh.vertices [1];  
		Vector3 side0Panel12 = sidePanel0Script.mesh.vertices [12]; 
		Vector3 side1Panel12 = sidePanel1Script.mesh.vertices [12]; 
		Vector3 side0Panel13 = sidePanel0Script.mesh.vertices [13]; 
		Vector3 side1Panel13 = sidePanel1Script.mesh.vertices [13]; 

		//Rim is just the same as the other windows
		mesh.vertices = new Vector3[] { 

			grill0,
			grill1,
			side1Panel12,
			side0Panel12,
			side1Panel13,
			side0Panel13	
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 3,5,4, 3,4,2, 1,3,2, 1,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
