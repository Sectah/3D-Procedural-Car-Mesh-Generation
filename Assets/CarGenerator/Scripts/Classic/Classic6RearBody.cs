using UnityEngine;

public class Classic6RearBody : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	private float depth;
	private float gap;

	//Declare the script of the prevous mesh
	Classic5Windscreen windscreen;

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

		windscreen = FindObjectOfType<Classic5Windscreen> ();
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh	
		RandomControl dc = FindObjectOfType<RandomControl> ();
		depth = Random.Range (dc.classicModel.RearBody.Depth.x, dc.classicModel.RearBody.Depth.y);
		gap = Random.Range (dc.classicModel.RearBody.Gap.x, dc.classicModel.RearBody.Gap.y);

		//depth = Random.Range (1.75f, 4.25f);
		//gap = Random.Range(2.5f, 6.75f);
		Vector3 previous2 = windscreen.mesh.vertices [0];
		Vector3 previous3 = windscreen.mesh.vertices [1];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (previous2.x, previous2.y, previous2.z + gap),
			new Vector3 (previous3.x, previous3.y, previous3.z + gap),
			new Vector3 (previous2.x, previous2.y, previous2.z + gap + depth),
			new Vector3 (previous3.x, previous3.y, previous3.z + gap + depth)
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
