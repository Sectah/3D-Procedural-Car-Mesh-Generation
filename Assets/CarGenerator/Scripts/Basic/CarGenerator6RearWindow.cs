using UnityEngine;

public class CarGenerator6RearWindow: MonoBehaviour {

	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;

	private float depth;
	private float rim;

	//Declare the scripts required
	CarGenerator5Roof roofScript;
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
		roofScript = FindObjectOfType<CarGenerator5Roof> ();
		bonnetScript = FindObjectOfType<CarGenerator2Bonnet> ();

		//Call the create mesh function
		CreateMesh ();
	}

	void CreateMesh () {

		//Find the data collator class and get the data from it
		RandomControl dc = FindObjectOfType<RandomControl> ();
		depth = Random.Range (dc.basicModel.RearWindow.Depth.x, dc.basicModel.RearWindow.Depth.y);
		rim = Random.Range (dc.basicModel.RearWindow.Rim.x, dc.basicModel.RearWindow.Rim.y);
		Vector3 bonnet2 = bonnetScript.mesh.vertices [2];
		Vector3 bonnet3 = bonnetScript.mesh.vertices [3];
		Vector3 previous2 = roofScript.mesh.vertices [2];
		Vector3 previous3 = roofScript.mesh.vertices [3];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (bonnet2.x, bonnet2.y, previous2.z + depth),
			new Vector3 (bonnet3.x, bonnet3.y, previous3.z + depth),
			new Vector3 (bonnet2.x + rim, bonnet2.y + rim, previous2.z + (depth - rim)),
			new Vector3 (bonnet3.x - rim, bonnet3.y + rim, previous3.z + (depth - rim)),
			new Vector3 (previous3.x, previous3.y, previous3.z),
			new Vector3 (previous3.x - rim, previous3.y - rim, previous3.z + (rim / 2)),
			new Vector3 (previous2.x, previous2.y, previous2.z),
			new Vector3 (previous2.x + rim, previous2.y - rim, previous2.z + (rim / 2))
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,7, 0,7,6 ,7,5,6, 6,5,4, 5,3,4, 4,3,1, 1,3,2, 1,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
