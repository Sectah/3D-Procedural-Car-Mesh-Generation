using UnityEngine;

public class Classic9Bottom : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	//Declare the script of the front and back meshes
	Classic8RearBottom rearBottom;
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

		rearBottom = FindObjectOfType<Classic8RearBottom> ();
		frontBumper = FindObjectOfType<Classic1FrontBumper> ();
		CreateMesh ();
	}
	
	void CreateMesh () {

		//Assign random values to the depth of the mesh	
		Vector3 previous0 = frontBumper.mesh.vertices[0];
		Vector3 previous1 = frontBumper.mesh.vertices[1];
		Vector3 previous2 = rearBottom.mesh.vertices [2];
		Vector3 previous3 = rearBottom.mesh.vertices [3];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			previous0,
			previous1,
			previous2,
			previous3
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 1,3,2, 1,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
