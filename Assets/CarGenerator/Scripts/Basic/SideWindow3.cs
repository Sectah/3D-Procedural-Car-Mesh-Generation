using UnityEngine;

public class SideWindow3 : MonoBehaviour {
	
	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;

	private float rim;

	//All the scripts I need to connect the windows to the side of the mesh
	SideWindow2 sideWindow2Script;
	CarGenerator6RearWindow rearWindowScript;
	SideWindow1 sideWindow1Script;

	void Start () {

		//Create a mesh filter while also assigning it as a variable to get the mesh property
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter> ();

		//Create a mesh renderer so we can actually display the mesh
		gameObject.AddComponent<MeshRenderer> ();

		//Set the mesh object to be that of the mesh from the mesh filter
		mesh = meshFilter.mesh;

		//Set a random material from the "Resources/" folder. Length - 2 to avoid Window & Wheel texture
		Object[] loadedMaterials = Resources.LoadAll ("Materials");
		gameObject.GetComponent<Renderer> ().material = (Material)loadedMaterials [Random.Range (0, loadedMaterials.Length - 2)];

		//Get the scripts
		sideWindow1Script = FindObjectOfType<SideWindow1> ();
		sideWindow2Script = FindObjectOfType<SideWindow2> ();
		rearWindowScript = FindObjectOfType<CarGenerator6RearWindow> ();

		//Call the create mesh function
		CreateMesh ();
	}

	void CreateMesh () {

		//Getting all the positional data from previous meshes
		Vector3 sideWindow4 = sideWindow2Script.mesh.vertices [4];	
		Vector3 sideWindow1 = sideWindow2Script.mesh.vertices [1];
		Vector3 rearWindow6 = rearWindowScript.mesh.vertices [6];	
		Vector3 rearWindow0 = rearWindowScript.mesh.vertices [0];

		//Rim is just the same as the other windows
		rim = sideWindow1Script.rim;

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (sideWindow1.x, sideWindow1.y, sideWindow1.z),					
			new Vector3 (rearWindow0.x, rearWindow0.y, rearWindow0.z),					
			new Vector3 (sideWindow1.x, sideWindow1.y + rim, sideWindow1.z + rim),		
			new Vector3 (rearWindow0.x, rearWindow0.y + rim, rearWindow0.z - (rim * 2)),
			new Vector3 (rearWindow6.x, rearWindow6.y, rearWindow6.z),					
			new Vector3 (rearWindow6.x, rearWindow6.y - rim, rearWindow6.z - rim),		
			new Vector3 (sideWindow4.x, sideWindow4.y, sideWindow4.z),					
			new Vector3 (sideWindow4.x, sideWindow4.y - rim, sideWindow4.z + rim)		
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0, 2, 7, 0, 7, 6, 7, 5, 6, 6, 5, 4, 5, 3, 4, 4, 3, 1, 1, 3, 2, 1, 2, 0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}