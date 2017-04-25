using UnityEngine;

public class Classic8RearBottom : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	private float height;
	private float depth;

	//Declare the script of the prevous mesh and first mesh to match height
	Classic7RearTop rearBody;
	Classic1FrontBumper frontBumper;

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

		rearBody = FindObjectOfType<Classic7RearTop> ();
		frontBumper = FindObjectOfType<Classic1FrontBumper> ();
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh	
		RandomControl dc = FindObjectOfType<RandomControl> ();
		depth = Random.Range (dc.classicModel.RearBottom.Depth.x, dc.classicModel.RearBottom.Depth.y);

		height = frontBumper.mesh.vertices[0].y;
		//depth = Random.Range (-0.50f, -1.75f);
		Vector3 previous2 = rearBody.mesh.vertices [2];
		Vector3 previous3 = rearBody.mesh.vertices [3];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (previous2.x, previous2.y, previous2.z),
			new Vector3 (previous3.x, previous3.y, previous3.z),
			new Vector3 (previous2.x, height, previous2.z + depth),
			new Vector3 (previous3.x, height, previous3.z + depth)
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
