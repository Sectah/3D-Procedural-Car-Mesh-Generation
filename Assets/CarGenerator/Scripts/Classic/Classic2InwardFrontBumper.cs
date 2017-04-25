using UnityEngine;

public class Classic2InwardFrontBumper : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	private float height;
	private float depth;

	//Declare the script of the prevous mesh
	Classic1FrontBumper frontBumper;

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

		//Get script of previous mesh
		frontBumper = FindObjectOfType<Classic1FrontBumper> ();

		//Create the mesh
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh
		RandomControl dc = FindObjectOfType<RandomControl> ();
		height = Random.Range (dc.classicModel.InwardFrontBumper.Height.x, dc.classicModel.InwardFrontBumper.Height.y);
		depth = Random.Range (dc.classicModel.InwardFrontBumper.Depth.x, dc.classicModel.InwardFrontBumper.Depth.y);

		//height = Random.Range(0f, 0.5f);
		//depth = Random.Range (0.05f, 0.75f);

		Vector3 previous2 = frontBumper.mesh.vertices [2];
		Vector3 previous3 = frontBumper.mesh.vertices [3];

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
}
