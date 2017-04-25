using UnityEngine;

public class Van13Underside : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	//Debugging for visualisation
	[Header("HIDE/SHOW NORMAL DEBUG")]
	public bool showNormals = false;

	//Declare the script of the prevous mesh
	Van1BumperUnderside frontBumper;
	Van12RearBumperDown rearBumper;

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

		//Get script of previous mesh
		frontBumper = GameObject.Find("Van1BumperUnderside").GetComponent<Van1BumperUnderside>();
		rearBumper = GameObject.Find("Van12RearBumperDown").GetComponent<Van12RearBumperDown>();

		//Create the mesh
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh
		Vector3 front2 = frontBumper.mesh.vertices [0];
		Vector3 front3 = frontBumper.mesh.vertices [1];
		Vector3 rear2 = rearBumper.mesh.vertices [2];
		Vector3 rear3 = rearBumper.mesh.vertices [3];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			front2,
			front3,
			rear2,
			rear3
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 1,3,2, 1,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}

	void Update () {

		//Draw some rays to represent the normals for debugging purposes
		if (showNormals) {

			for (int i = 0; i < mesh.vertices.Length - 1; i++) {

				Vector3 forward = transform.TransformDirection (mesh.normals [i]) * 2;
				Debug.DrawRay (mesh.vertices [i], forward, Color.green);
				Debug.DrawRay (mesh.vertices [i + 1], forward, Color.green);
				Debug.DrawRay (Vector3.Lerp (mesh.vertices [i], mesh.vertices [i + 1], 0.5f), forward, Color.green);
			}
		}
	}
}
