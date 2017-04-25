using UnityEngine;

public class CarGenerator2Bonnet : MonoBehaviour {

	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;

	private float height;
	private float depth;

	//Declare the script of the previous mesh
	CarGenerator1GrillToBonnet grillToBonnetData;

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

		//Get the previous mesh script
		grillToBonnetData = FindObjectOfType<CarGenerator1GrillToBonnet> ();

		//Call the create mesh function
		CreateMesh ();
	}

	void CreateMesh () {
		
		//Find the data collator class and get the data from it
		RandomControl dc = FindObjectOfType<RandomControl> ();
		height = Random.Range (dc.basicModel.Bonnet.Height.x, dc.basicModel.Bonnet.Height.y);
		depth = Random.Range (dc.basicModel.Bonnet.Depth.x, dc.basicModel.Bonnet.Depth.y);
		Vector3 previous2 = grillToBonnetData.mesh.vertices [2];
		Vector3 previous3 = grillToBonnetData.mesh.vertices [3];

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
