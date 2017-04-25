using UnityEngine;

public class Classic1FrontBumper : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	private float width;
	private float height;

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

		//Call the create mesh function
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the width, height of the mesh
		RandomControl dc = FindObjectOfType<RandomControl> ();
		width = Random.Range (dc.classicModel.Width.x, dc.classicModel.Width.y);
		height = Random.Range (dc.classicModel.FrontBumper.Height.x, dc.classicModel.FrontBumper.Height.y);

		//width = Random.Range (5.75f, 8.25f);
		//height = Random.Range (0.07f, 0.78f);

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (0, 0, 0),
			new Vector3 (width, 0, 0),
			new Vector3 (0, height, 0),
			new Vector3 (width, height, 0)	
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
