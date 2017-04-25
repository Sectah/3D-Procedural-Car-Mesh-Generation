using UnityEngine;

public class VanUpperSidePanel1 : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	//Declare the script of the prevous mesh
	Van9RearSlant rearSlant;
	VanSideWindow1 sideWindow;

	void Start () {

		//Create a mesh filter while also assigning it as a variable to get the mesh property
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter> ();

		//Create a mesh renderer so we can actually display the mesh
		gameObject.AddComponent<MeshRenderer> ();

		//Set the mesh object to be that of the mesh from the mesh filter
		mesh = meshFilter.mesh;

		//Set the same material as the side panel
		gameObject.GetComponent<Renderer> ().material = GameObject.Find ("VanSidePanel1").GetComponent<Renderer> ().material;

		//Get script of previous mesh
		rearSlant = GameObject.Find ("Van9RearSlant").GetComponent<Van9RearSlant> ();
		sideWindow = GameObject.Find ("VanSideWindow1").GetComponent<VanSideWindow1> ();

		//Create the mesh
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh
		Vector3 sideWindow4 = sideWindow.mesh.vertices [4];
		Vector3 sideWindow1 = sideWindow.mesh.vertices [1];
		Vector3 rearSlant1 = rearSlant.mesh.vertices [0];
		Vector3 rearSlant3 = rearSlant.mesh.vertices [2];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			sideWindow1,
			new Vector3(sideWindow1.x, sideWindow1.y, rearSlant1.z),
			sideWindow4,
			rearSlant1,
			rearSlant3,
			new Vector3(rearSlant3.x, rearSlant3.y, rearSlant1.z),
			new Vector3(sideWindow1.x, sideWindow1.y, rearSlant3.z)
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 6,4,5, 1,6,5, 5,4,3, 1,3,2, 0,1,2 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
