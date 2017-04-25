using UnityEngine;

public class SidePanel1 : MonoBehaviour {

	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;

	//All the scripts I need to connect the panel to the mesh
	CarGenerator0Grill grillScript;
	CarGenerator1GrillToBonnet grillToBonnetScript;
	CarGenerator2Bonnet bonnetScript;
	CarGenerator3BonnetToWindscreen bonnetToWindscreenScript;
	CarGenerator7RearPanel rearPanelScript;
	CarGenerator8Backend backendScript;

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
		grillScript = FindObjectOfType<CarGenerator0Grill> ();
		grillToBonnetScript = FindObjectOfType<CarGenerator1GrillToBonnet> ();
		bonnetScript = FindObjectOfType<CarGenerator2Bonnet> ();
		bonnetToWindscreenScript = FindObjectOfType<CarGenerator3BonnetToWindscreen> ();
		rearPanelScript = FindObjectOfType<CarGenerator7RearPanel> ();
		backendScript = FindObjectOfType<CarGenerator8Backend> ();

		//Call the create mesh function
		CreateMesh ();
	}

	void CreateMesh () {
		
		//Getting all the positional data from previous meshes
		Vector3 grill1 = grillScript.mesh.vertices [0];
		Vector3 grill3 = grillScript.mesh.vertices [2];
		Vector3 grillToBonnet3 = grillToBonnetScript.mesh.vertices [2];
		Vector3 bonnet3 = bonnetScript.mesh.vertices [2];
		Vector3 bonnetToWindscreen3 = bonnetToWindscreenScript.mesh.vertices [2];
		Vector3 rearPanel1 = rearPanelScript.mesh.vertices [0];
		Vector3 rearPanel3 = rearPanelScript.mesh.vertices [2];
		Vector3 backendPanel3 = backendScript.mesh.vertices [2];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (grill1.x, grill1.y, grill1.z),
			new Vector3 (grill1.x, grill1.y, grillToBonnet3.z),
			new Vector3 (grill1.x, grill3.y, grill3.z),
			new Vector3 (grill1.x, grill3.y,  grillToBonnet3.z),
			new Vector3 (grill1.x, grillToBonnet3.y, grillToBonnet3.z),
			new Vector3 (bonnet3.x, bonnet3.y, bonnet3.z),
			new Vector3 (bonnet3.x, grill1.y, bonnet3.z),
			new Vector3 (bonnetToWindscreen3.x, bonnetToWindscreen3.y, bonnetToWindscreen3.z),
			new Vector3 (bonnetToWindscreen3.x, grill1.y, bonnetToWindscreen3.z),
			new Vector3 (rearPanel1.x, rearPanel1.y, rearPanel1.z),
			new Vector3 (rearPanel1.x, grill1.y, rearPanel1.z),
			new Vector3 (rearPanel3.x, rearPanel3.y, rearPanel3.z),
			new Vector3 (rearPanel3.x, grill1.y, rearPanel3.z),
			new Vector3 (backendPanel3.x, backendPanel3.y, backendPanel3.z)
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 13,11,12, 12,11,10, 10,11,9, 10,9,8, 9,7,8, 8,7,6, 7,5,6, 6,5,1, 1,5,4, 4,2,3, 1,3,2, 1,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
