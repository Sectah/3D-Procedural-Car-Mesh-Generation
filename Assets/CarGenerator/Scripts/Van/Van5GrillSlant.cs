using UnityEngine;

public class Van5GrillSlant : MonoBehaviour {
	
	[HideInInspector] public Mesh mesh;
	private float height;
	private float depth;

	//Declare the script of the prevous mesh
	Van4Grill grill;

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
		grill = FindObjectOfType<Van4Grill>();

		//Create the mesh
		CreateMesh ();	
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh
		RandomControl dc = FindObjectOfType<RandomControl> ();
		height = Random.Range (dc.vanModel.GrillSlant.Height.x, dc.vanModel.GrillSlant.Height.y);
		depth = Random.Range (dc.vanModel.GrillSlant.Height.x, dc.vanModel.GrillSlant.Height.y);

		//height = Random.Range(0.1f, 0.4f);
		//depth = Random.Range (0.07f, 0.47f);
		Vector3 previous2 = grill.mesh.vertices [2];
		Vector3 previous3 = grill.mesh.vertices [3];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (previous2.x, previous2.y, previous2.z),
			new Vector3 (previous3.x, previous3.y, previous3.z),
			new Vector3 (previous2.x, previous2.y + height, previous2.z + depth),
			new Vector3 (previous3.x, previous3.y + height, previous3.z + depth)
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}

	void Update () {

		//Debug the normals
		for (int i = 0; i < mesh.vertices.Length - 1; i++) {

			Vector3 forward = transform.TransformDirection (mesh.normals [i]) * 2;
			Debug.DrawRay (mesh.vertices [i], forward, Color.green);
			Debug.DrawRay (mesh.vertices [i + 1], forward, Color.green);
			Debug.DrawRay (Vector3.Lerp (mesh.vertices [i], mesh.vertices [i + 1], 0.5f), forward, Color.green);
		}
	}
}
