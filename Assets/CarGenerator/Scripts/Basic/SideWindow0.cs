using UnityEngine;

public class SideWindow0: MonoBehaviour {

	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;
	[HideInInspector] public float randT;
	[HideInInspector] public float rim;

	//All the scripts I need to connect the windows to the side of the mesh
	SidePanel0 sidePanelScript;
	CarGenerator4Windscreen windscreenScript;
	CarGenerator5Roof roofScript;

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
		sidePanelScript = GameObject.Find ("SidePanel0").GetComponent<SidePanel0> ();
		windscreenScript = GameObject.Find ("CarGenerator4Windscreen").GetComponent<CarGenerator4Windscreen> ();
		roofScript = GameObject.Find ("CarGenerator5Roof").GetComponent<CarGenerator5Roof> ();

		//Call the create mesh function
		CreateMesh ();
	}

	void CreateMesh () {

		//Getting all the positional data from previous meshes
		Vector3 windscreen1 = windscreenScript.mesh.vertices [1];
		Vector3 windscreen4 = windscreenScript.mesh.vertices [4];
		Vector3 roof1 = roofScript.mesh.vertices [1];
		Vector3 roof3 = roofScript.mesh.vertices [3];
		Vector3 sidePanel7 = sidePanelScript.mesh.vertices[7];
		Vector3 sidePanel9 = sidePanelScript.mesh.vertices[9];

		//Random values for the linear interp and the size of the rims
		randT = Random.Range (0.5f, 0.75f);
		rim = Random.Range (0.1f, 0.15f);
		Vector3 randomPoint0 = Vector3.Lerp (roof1, roof3, randT);
		Vector3 randomPoint1 = Vector3.Lerp (sidePanel7, sidePanel9, randT);

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (windscreen1.x, windscreen1.y, windscreen1.z),						
			new Vector3 (windscreen1.x, randomPoint1.y, randomPoint1.z),					
			new Vector3 (windscreen1.x, windscreen1.y + rim, windscreen1.z + (rim * 2)),		
			new Vector3 (windscreen1.x, randomPoint1.y + rim, randomPoint1.z - rim),		
			new Vector3 (windscreen4.x, randomPoint0.y, randomPoint0.z),					
			new Vector3 (windscreen4.x, randomPoint0.y - rim, randomPoint0.z - rim),		
			new Vector3 (windscreen4.x, windscreen4.y, windscreen4.z),						
			new Vector3 (windscreen4.x, windscreen4.y - rim, windscreen4.z + rim)			
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1, 1,3,4, 4,3,5, 4,5,6, 6,5,7, 6,7,0, 7,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
