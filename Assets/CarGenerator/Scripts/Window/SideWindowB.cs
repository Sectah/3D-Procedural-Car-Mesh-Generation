using UnityEngine;

public class SideWindowB : MonoBehaviour {

	private Mesh mesh;

	void Start () {

		//Create a mesh filter while also assigning it as a variable to get the mesh property
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter> ();

		//Create a mesh renderer so we can actually display the mesh
		gameObject.AddComponent<MeshRenderer> ();

		//Set the mesh object to be that of the mesh from the mesh filter
		mesh = meshFilter.mesh;

		//Set a random material
		Object[] loadedMaterials = Resources.LoadAll("Materials");
		gameObject.GetComponent<Renderer> ().material = (Material)loadedMaterials [loadedMaterials.Length - 1];

		if (GameObject.FindObjectOfType<CreateCar> ().model == CreateCar.Model.Basic) {

			CreateBasicWindow ();

		} else if (GameObject.FindObjectOfType<CreateCar> ().model == CreateCar.Model.Van) {

			CreateVanWindow ();
		}
	}

	void CreateBasicWindow () {

		//Get the basic car model windscreen script
		SideWindow1 basicWindscreen = GameObject.Find ("SideWindow1").GetComponent<SideWindow1> ();

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] {

			basicWindscreen.mesh.vertices [2],
			basicWindscreen.mesh.vertices [3],
			basicWindscreen.mesh.vertices [7],
			basicWindscreen.mesh.vertices [5]
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}

	void CreateVanWindow () {

		//Get the basic car model windscreen script
		VanSideWindow1 basicWindscreen = GameObject.Find ("VanSideWindow1").GetComponent<VanSideWindow1> ();

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] {

			basicWindscreen.mesh.vertices [2],
			basicWindscreen.mesh.vertices [3],
			basicWindscreen.mesh.vertices [7],
			basicWindscreen.mesh.vertices [5]
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 1,3,2, 1,2,0 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
