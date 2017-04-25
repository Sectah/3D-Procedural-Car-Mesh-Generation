using UnityEngine;

public class SideWindowC : MonoBehaviour {

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
		}
	}

	void CreateBasicWindow () {

		//Get the basic car model windscreen script
		SideWindow2 basicWindscreen = GameObject.Find ("SideWindow2").GetComponent<SideWindow2> ();

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
