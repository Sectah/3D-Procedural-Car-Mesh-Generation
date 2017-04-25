using UnityEngine;

public class CarGenerator0Grill : MonoBehaviour {

	//Allow for next mesh to access data from this mesh
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

		//Set a random material from the "Resources/" folder. Length - 2 to avoid Window & Wheel texture
		Object[] loadedMaterials = Resources.LoadAll ("Materials");
		gameObject.GetComponent<Renderer> ().material = (Material)loadedMaterials [Random.Range (0, loadedMaterials.Length - 2)];

		//Call the create mesh function
		CreateMesh ();
	}

	void CreateMesh () {

		//Find the data collator class and get the data from it
		RandomControl dc = FindObjectOfType<RandomControl> ();
		width = Random.Range (dc.basicModel.Width.x, dc.basicModel.Width.y);
		height = Random.Range (dc.basicModel.Grill.Height.x, dc.basicModel.Grill.Height.y);
		depth = Random.Range (dc.basicModel.Grill.Depth.x, dc.basicModel.Grill.Depth.y);

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
}
