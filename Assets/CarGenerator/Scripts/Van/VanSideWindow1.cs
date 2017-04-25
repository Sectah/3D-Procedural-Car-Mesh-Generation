using UnityEngine;

public class VanSideWindow1 : MonoBehaviour {

	//Allow for next mesh to access data from this mesh
	[HideInInspector] public Mesh mesh;

	//Just for debugging purposes
	[Header("POSITIONAL DATA")]
	public float randT;
	public float rim;

	private bool showNormals = true;

	//All the scripts I need to connect the windows to the side of the mesh
	VanSideWindow0 sideWindow;
	VanSidePanel1 sidePanel;
	Van7Windscreen windscreen;
	Van8Roof roof;

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

		//Get script of previous mesh
		sideWindow = GameObject.Find("VanSideWindow0").GetComponent<VanSideWindow0>();
		sidePanel = GameObject.Find("VanSidePanel1").GetComponent<VanSidePanel1>();
		windscreen = GameObject.Find("Van7Windscreen").GetComponent<Van7Windscreen>();
		roof = GameObject.Find("Van8Roof").GetComponent<Van8Roof>();

		//Create the mesh
		CreateMesh ();
	}

	void CreateMesh () {

		//Getting all the positional data from previous meshes
		Vector3 windscreen1 = windscreen.mesh.vertices [0];
		Vector3 windscreen4 = windscreen.mesh.vertices [6];
		Vector3 roof1 = roof.mesh.vertices [0];
		Vector3 roof3 = roof.mesh.vertices [2];
		Vector3 sidePanel7 = sidePanel.mesh.vertices[7];
		Vector3 sidePanel9 = sidePanel.mesh.vertices[9];

		//Random values for the linear interp and the size of the rims
		randT = sideWindow.randT;
		rim = sideWindow.rim;
		Vector3 randomPoint0 = Vector3.Lerp (roof1, roof3, randT);
		Vector3 randomPoint1 = Vector3.Lerp (sidePanel7, sidePanel9, randT);

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			new Vector3 (windscreen1.x, windscreen1.y, windscreen1.z),						
			new Vector3 (windscreen1.x, randomPoint1.y, randomPoint0.z),					
			new Vector3 (windscreen1.x, windscreen1.y + rim, windscreen1.z + (rim*2)),		
			new Vector3 (windscreen1.x, randomPoint1.y + rim, randomPoint0.z - rim),		
			new Vector3 (windscreen4.x, randomPoint0.y, randomPoint0.z),					
			new Vector3 (windscreen4.x, randomPoint0.y - rim, randomPoint0.z - rim),		
			new Vector3 (windscreen4.x, windscreen4.y, windscreen4.z),						
			new Vector3 (windscreen4.x, windscreen4.y - rim, windscreen4.z + rim)			
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,7, 0,7,6, 7,5,6, 6,5,4, 5,3,4, 4,3,1, 1,3,2, 1,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}

	void Update () {

		//Draw some rays to represent the normals for debugging purposes
		if (showNormals) {


			Vector3 forward = transform.TransformDirection (mesh.normals [4]) * 2;
			Debug.DrawRay (mesh.vertices [4], forward, Color.green);
		}
	}
}
