using UnityEngine;

public class Classic4BonnetPartA : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	private float height;
	private float depth;

	//Declare the script of the prevous mesh
	Classic3UpwardFrontBumper upwardFrontBumper;

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

		upwardFrontBumper = FindObjectOfType<Classic3UpwardFrontBumper> ();

		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh
		RandomControl dc = FindObjectOfType<RandomControl> ();
		height = Random.Range (dc.classicModel.BonnetPartA.Height.x, dc.classicModel.BonnetPartA.Height.y);
		depth = Random.Range (dc.classicModel.BonnetPartA.Depth.x, dc.classicModel.BonnetPartA.Depth.y);

		//height = Random.Range (-0.3f, 0.3f);	
		//depth = Random.Range (1.87f, 2.78f);

		Vector3 previous2 = upwardFrontBumper.mesh.vertices [2];
		Vector3 previous3 = upwardFrontBumper.mesh.vertices [3];

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
