using UnityEngine;

public class CarGenerator7RearPanel : MonoBehaviour {

	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;

	private float height;
	private float depth;

	//Declare the scripts required
	CarGenerator6RearWindow rearWindowScript;
	CarGenerator2Bonnet bonnetScript;

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
		rearWindowScript = FindObjectOfType<CarGenerator6RearWindow> ();
		bonnetScript = FindObjectOfType<CarGenerator2Bonnet> ();

		//Call the create mesh function
		CreateMesh ();
	}

	void CreateMesh () {

		//Find the data collator class and get the data from it
		RandomControl dc = FindObjectOfType<RandomControl> ();
		height = Random.Range (dc.basicModel.RearPanel.Height.x, dc.basicModel.RearPanel.Height.y);
		depth = Random.Range (dc.basicModel.RearPanel.Depth.x, dc.basicModel.RearPanel.Depth.y);
		Vector3 bonnet2 = bonnetScript.mesh.vertices [2];
		Vector3 bonnet3 = bonnetScript.mesh.vertices [3];
		Vector3 previous0 = rearWindowScript.mesh.vertices [0];
		Vector3 previous1 = rearWindowScript.mesh.vertices [1];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (previous0.x, previous0.y, previous0.z),
			new Vector3 (previous1.x, previous1.y, previous1.z),
			new Vector3 (previous0.x, bonnet2.y - height, previous0.z + depth),
			new Vector3 (previous1.x, bonnet3.y - height, previous1.z + depth)
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
