using UnityEngine;

public class VanSidePanel1 : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	//Debugging for visualisation
	private bool showNormals = true;

	//Declare the script of the prevous mesh
	Van1BumperUnderside bumperUnderside;
	Van3BumperInward bumperInward;
	Van5GrillSlant grillSlant;
	Van6Bonnet bonnet;
	Van10RearEnd rearEnd;
	Van11RearBumper rearBumper;
	Van12RearBumperDown rearBumperDown;

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
		bumperUnderside = GameObject.Find("Van1BumperUnderside").GetComponent<Van1BumperUnderside>();
		bumperInward = GameObject.Find("Van3BumperInward").GetComponent<Van3BumperInward>();
		grillSlant = GameObject.Find ("Van5GrillSlant").GetComponent<Van5GrillSlant> ();
		bonnet = GameObject.Find ("Van6Bonnet").GetComponent<Van6Bonnet> ();
		rearEnd = GameObject.Find ("Van10RearEnd").GetComponent<Van10RearEnd> ();
		rearBumper = GameObject.Find ("Van11RearBumper").GetComponent<Van11RearBumper> ();
		rearBumperDown = GameObject.Find ("Van12RearBumperDown").GetComponent<Van12RearBumperDown> ();

		//Create the mesh
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh
		Vector3 bumperUnderside1 = bumperUnderside.mesh.vertices[0];
		Vector3 bumperUnderside3 = bumperUnderside.mesh.vertices[2];
		Vector3 bumperInward1 = bumperInward.mesh.vertices [0];
		Vector3 bumperInward3 = bumperInward.mesh.vertices [2];
		Vector3 grillSlant1 = grillSlant.mesh.vertices [0];
		Vector3 grillSlant3 = grillSlant.mesh.vertices [2];
		Vector3 bonnet3 = bonnet.mesh.vertices [2];
		Vector3 rearEnd1 = rearEnd.mesh.vertices [0];
		Vector3 rearBumper1 = rearBumper.mesh.vertices [0];
		Vector3 rearBumper3 = rearBumper.mesh.vertices [2];
		Vector3 rearBumperDown3 = rearBumperDown.mesh.vertices [2];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			bumperUnderside1,
			bumperUnderside3,
			bumperInward1,
			bumperInward3,
			new Vector3(bumperUnderside1.x, bumperUnderside1.y, grillSlant3.z),
			grillSlant1,
			grillSlant3,
			bonnet3,
			new Vector3(bumperUnderside1.x, bumperUnderside1.y, bonnet3.z),
			new Vector3(bumperUnderside1.x, bonnet3.y, rearEnd1.z),
			new Vector3(bumperUnderside1.x, bumperUnderside1.y, rearEnd1.z),
			rearBumper1,
			rearBumperDown3,
			rearBumper3
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 13,11,12, 10,12,11, 9,7,10, 8,10,7, 7,6,8, 4,8,6, 6,5,4, 0,4,5, 3,2,0, 1,0,2 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}

	void Update () {

		//Draw some rays to represent the normals for debugging purposes
		if (showNormals) {

			Vector3 forward = transform.TransformDirection (mesh.normals [7]) * 2;
			Debug.DrawRay (mesh.vertices [7], forward, Color.green);
		}
	}
}
