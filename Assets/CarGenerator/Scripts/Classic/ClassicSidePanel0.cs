using UnityEngine;

public class ClassicSidePanel0 : MonoBehaviour {

	[HideInInspector] public Mesh mesh;

	//Declare the scripts needed to attach a side panel
	Classic1FrontBumper frontBumper;
	Classic3UpwardFrontBumper upwardFrontBumper;
	Classic4BonnetPartA bonnetPartA;
	Classic4BonnetPartB bonnetPartB;
	Classic6RearBody rearBody;
	Classic8RearBottom rearBottom;

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

		frontBumper = GameObject.Find ("Classic1FrontBumper").GetComponent<Classic1FrontBumper> ();
		upwardFrontBumper = GameObject.Find ("Classic3UpwardFrontBumper").GetComponent <Classic3UpwardFrontBumper> ();
		bonnetPartA = GameObject.Find ("Classic4BonnetPartA").GetComponent<Classic4BonnetPartA> ();
		bonnetPartB = GameObject.Find ("Classic4BonnetPartB").GetComponent<Classic4BonnetPartB> ();
		rearBody = GameObject.Find ("Classic6RearBody").GetComponent<Classic6RearBody> ();
		rearBottom = GameObject.Find ("Classic8RearBottom").GetComponent<Classic8RearBottom> ();
		CreateMesh ();
	}

	void CreateMesh () {

		//Assign random values to the depth of the mesh	
		Vector3 frontBumper1 = frontBumper.mesh.vertices[1];
		Vector3 frontBumper3 = frontBumper.mesh.vertices [3];
		Vector3 upwardFrontBumper1 = upwardFrontBumper.mesh.vertices [1];
		Vector3 bonnetPartA1 = bonnetPartA.mesh.vertices [1];
		Vector3 bonnetPartA3 = bonnetPartA.mesh.vertices [3];
		Vector3 bonnetPartB3 = bonnetPartB.mesh.vertices [3];
		Vector3 rearBody1 = rearBody.mesh.vertices [1];
		Vector3 rearBody3 = rearBody.mesh.vertices [3];
		Vector3 rearBottom1 = rearBottom.mesh.vertices [1];
		Vector3 rearBottom3 = rearBottom.mesh.vertices [3];

		//Assign the mesh vertices
		mesh.vertices = new Vector3[] { 

			(frontBumper1),														
			new Vector3 (frontBumper1.x, frontBumper1.y, upwardFrontBumper1.z),			
			new Vector3 (frontBumper1.x, frontBumper3.y, frontBumper3.z),				
			new Vector3 (frontBumper1.x, upwardFrontBumper1.y, upwardFrontBumper1.z), 	
			new Vector3 (frontBumper1.x, frontBumper1.y, bonnetPartA3.z),				
			new Vector3 (frontBumper1.x, bonnetPartA1.y, bonnetPartA1.z),				
			new Vector3 (frontBumper1.x, bonnetPartA3.y, bonnetPartA3.z),				
			new Vector3 (frontBumper1.x, frontBumper1.y, bonnetPartB3.z),				
			new Vector3 (frontBumper1.x, bonnetPartB3.y, bonnetPartB3.z),				
			new Vector3 (frontBumper1.x, frontBumper1.y, rearBody1.z), 					
			new Vector3 (frontBumper1.x, rearBody1.y, rearBody1.z),						
			new Vector3 (frontBumper1.x, frontBumper1.y, rearBottom3.z),				
			(rearBody3),																
			(rearBottom1)																
		};

		//Assign the mesh triangles
		mesh.triangles = new int[] { 0,2,1, 2,3,1, 1,5,4, 4,5,6, 4,6,7, 6,8,7, 7,8,9, 8,10,9, 11,9,10, 10,12,11, 13,11,12 };

		//Calculate the normals of the mesh fom the triangles
		mesh.RecalculateNormals ();
	}
}
