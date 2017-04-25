using UnityEngine;

public class FrontWindow : MonoBehaviour {

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

		} else if (GameObject.FindObjectOfType<CreateCar> ().model == CreateCar.Model.Classic) {

			CreateClassicWindow ();

		} else if (GameObject.FindObjectOfType<CreateCar> ().model == CreateCar.Model.Van) {

			CreateVanWindow ();
		}
	}

	void CreateBasicWindow () {

		//Get the basic car model windscreen script
		CarGenerator4Windscreen basicWindscreen = GameObject.Find ("CarGenerator4Windscreen").GetComponent<CarGenerator4Windscreen> ();

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

	void CreateClassicWindow () {

		//Get the classic car model windscreen script
		Classic5Windscreen classicWindscreen = GameObject.Find ("Classic5Windscreen").GetComponent<Classic5Windscreen> ();

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] {

			classicWindscreen.mesh.vertices [2],
			classicWindscreen.mesh.vertices [3],
			classicWindscreen.mesh.vertices [7],
			classicWindscreen.mesh.vertices [5]
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}

	void CreateVanWindow () {

		//Get the classic car model windscreen script
		Van7Windscreen vanWindscreen = GameObject.Find ("Van7Windscreen").GetComponent<Van7Windscreen> ();

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] {

			vanWindscreen.mesh.vertices [2],
			vanWindscreen.mesh.vertices [3],
			vanWindscreen.mesh.vertices [7],
			vanWindscreen.mesh.vertices [5]
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
