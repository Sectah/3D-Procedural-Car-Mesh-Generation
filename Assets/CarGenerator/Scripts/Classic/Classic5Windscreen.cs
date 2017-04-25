using UnityEngine;

public class Classic5Windscreen : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	private float height;
	private float depth;
	private float rim;
	private float offset;

	//Declare the script of the prevous mesh
	Classic4BonnetPartB bonnetPartB;

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

		bonnetPartB = FindObjectOfType<Classic4BonnetPartB> ();
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the height, depth, and rims of the mesh
		RandomControl dc = FindObjectOfType<RandomControl> ();
		height = Random.Range (dc.classicModel.Windscreen.Height.x, dc.classicModel.Windscreen.Height.y);
		depth = Random.Range (dc.classicModel.Windscreen.Depth.x, dc.classicModel.Windscreen.Depth.y);
		rim = Random.Range (dc.classicModel.Windscreen.Rim.x, dc.classicModel.Windscreen.Rim.y);
		offset = Random.Range (dc.classicModel.Windscreen.TopOffset.x, dc.classicModel.Windscreen.TopOffset.y);

		//height = Random.Range (2.0f, 2.75f);
		//depth = Random.Range (0.5f, 3.5f);
		//rim = Random.Range (0.1f, 0.2f);
		//offset = Random.Range (0f, 0.5f);
		Vector3 previous2 = bonnetPartB.mesh.vertices [2];
		Vector3 previous3 = bonnetPartB.mesh.vertices [3];

		//Assign the mesh vertices
		mesh.vertices  = new Vector3[] { 

			new Vector3 (previous2.x, previous2.y, previous2.z),
			new Vector3 (previous3.x, previous3.y, previous3.z),
			new Vector3 (previous2.x + rim, previous2.y + rim, previous2.z + (rim/2)),
			new Vector3 (previous3.x - rim, previous2.y + rim, previous2.z + (rim/2)),
			new Vector3 (previous3.x - offset, previous3.y + (height + rim), previous3.z + depth),
			new Vector3 ((previous3.x - rim) - offset, previous3.y + height, previous3.z + (depth - rim)),
			new Vector3 (previous2.x + offset, previous2.y + (height + rim), previous2.z + depth),
			new Vector3 ((previous2.x + rim) + offset, previous2.y + height, previous2.z + (depth - rim))
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1, 1,3,4, 4,3,5, 4,5,6, 6,5,7, 6,7,0, 7,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
