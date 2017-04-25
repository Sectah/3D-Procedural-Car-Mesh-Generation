using UnityEngine;

public class Van1BumperUnderside : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	private float width;
	private float height;
	private float depth;

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

		//Call the create mesh function
		CreateMesh ();
	}
	
	void CreateMesh () {

		//Assign random values to the width, height of the mesh
		RandomControl dc = FindObjectOfType<RandomControl> ();
		width = Random.Range (dc.vanModel.Width.x, dc.vanModel.Width.y);
		height = Random.Range (dc.vanModel.BumperUnderside.Height.x, dc.vanModel.BumperUnderside.Height.y);
		depth = Random.Range (dc.vanModel.BumperUnderside.Depth.x, dc.vanModel.BumperUnderside.Depth.y);

		//width = Random.Range (5.75f, 8.25f);
		//height = Random.Range (0.3f, 0.4f);
		//depth = Random.Range (-0.7f, -0.1f);

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (0, 0, 0),
			new Vector3 (width, 0, 0),
			new Vector3 (0, height, depth),
			new Vector3 (width, height, depth)	
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}

	void Update () {

		//Draw some rays to represent the normals for debugging purposes
		for (int i = 0; i < mesh.vertices.Length - 1; i++) {

			Vector3 forward = transform.TransformDirection (mesh.normals [i]) * 2;
			Debug.DrawRay (mesh.vertices [i], forward, Color.green);
			Debug.DrawRay (mesh.vertices [i + 1], forward, Color.green);
			Debug.DrawRay (Vector3.Lerp (mesh.vertices [i], mesh.vertices [i + 1], 0.5f), forward, Color.green);
		}
	}
}
