using UnityEngine;

public class CreateCar : MonoBehaviour {

	[Header("RANDOMISE THE MODEL?")]
	public bool Randomise = true;

	public enum Model { Basic, Classic, Van };
	[Header("PICK YOUR MODEL")]
	public Model model;


	#region Basic model string names
	private string[] basicComponentNames = new string[] {

		"CarGenerator0Grill",
		"CarGenerator1GrillToBonnet",
		"CarGenerator2Bonnet",
		"CarGenerator3BonnetToWindscreen",
		"CarGenerator4Windscreen",
		"CarGenerator5Roof",
		"CarGenerator6RearWindow",
		"CarGenerator7RearPanel",
		"CarGenerator8Backend",
		"SidePanel0",
		"SidePanel1",
		"SideWindow0",
		"SideWindow1",
		"SideWindow2",
		"SideWindow3",
		"Underside"
	};
	#endregion

	#region Classic model string names
	private string[] classicComponentNames = new string[] {

		"Classic1FrontBumper",
		"Classic2InwardFrontBumper",
		"Classic3UpwardFrontBumper",
		"Classic4BonnetPartA",
		"Classic4BonnetPartB",
		"Classic5Windscreen",
		"Classic6RearBody",
		"Classic7RearTop",
		"Classic8RearBottom",
		"Classic9Bottom",
		"ClassicSidePanel0",
		"ClassicSidePanel1"
	};
	#endregion

	#region Van model string names
	private string[] vanComponentNames = new string[] {

		"Van1BumperUnderside",
		"Van2BumperStraight",
		"Van3BumperInward",
		"Van4Grill",
		"Van5GrillSlant",
		"Van6Bonnet",
		"Van7Windscreen",
		"Van8Roof",
		"Van9RearSlant",
		"Van10RearEnd",
		"Van11RearBumper",
		"Van12RearBumperDown",
		"Van13Underside",
		"VanSidePanel0",
		"VanSidePanel1",
		"VanSideWindow0",
		"VanSideWindow1",
		"VanUpperSidePanel0",
		"VanUpperSidePanel1"
	};
	#endregion

	#region Window string names
	private string[] windowNames = new string[] {

		"FrontWindow",
		"RearWindow",
		"SideWindowA",
		"SideWindowB",
		"SideWindowC",
		"SideWindowD"
	};
	#endregion

	#region Wheel string names
	private string[] wheelNames = new string[] {

		"Wheel0",
		"Wheel1",
		"Wheel2",
		"Wheel3"
	};
	#endregion

	void Start () {

		model = (Randomise) ? (Model)Random.Range (0, 3) : model;

		#region Car mesh
		GameObject car = new GameObject ();
		car.name = "Car";
		car.transform.position = Vector3.zero;
		car.transform.rotation = Quaternion.identity;
		car.AddComponent<MeshFilter> ();
		car.AddComponent<MeshRenderer> ();
		car.AddComponent<CombineMeshes> ();
		car.GetComponent<CombineMeshes> ().enabled = false;
		car.AddComponent<ShowOffModel> ();
		car.GetComponent<ShowOffModel> ().enabled = false;
		car.AddComponent<Explode>();
		car.GetComponent<Explode> ().enabled = false;
		Object[] loadedMaterials = Resources.LoadAll("Materials");
		car.GetComponent<Renderer> ().material = (Material)loadedMaterials [Random.Range (0, loadedMaterials.Length - 2)];

		if (model == Model.Basic) {

			for (int i = 0; i < basicComponentNames.Length; i++) {
			
				GameObject components = new GameObject (basicComponentNames [i]);
				UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent (components, "", basicComponentNames [i]);
				components.AddComponent<Backface> ();
				components.transform.SetParent (car.transform);
			}

		} else if (model == Model.Classic) {

			for (int i = 0; i < classicComponentNames.Length; i++) {

				GameObject components = new GameObject (classicComponentNames [i]);
				UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent (components, "", classicComponentNames [i]);
				components.AddComponent<Backface> ();
				components.transform.SetParent (car.transform);
			}

		} else if (model == Model.Van) {

			for (int i = 0; i < vanComponentNames.Length; i++) {

				GameObject components = new GameObject (vanComponentNames [i]);
				UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent (components, "", vanComponentNames [i]);
				components.AddComponent<Backface> ();
				components.transform.SetParent (car.transform);
			}
		}
		#endregion

		#region Window mesh
		GameObject windows = new GameObject ();
		windows.name = "Windows";
		transform.position = Vector3.zero;
		car.transform.rotation = Quaternion.identity;
		windows.AddComponent<MeshFilter> ();
		windows.AddComponent<MeshRenderer> ();
		windows.AddComponent<CombineMeshes> ();
		windows.GetComponent<CombineMeshes> ().enabled = false;
		windows.AddComponent<ShowOffModel> ();
		windows.GetComponent<ShowOffModel> ().enabled = false;
		windows.AddComponent<Explode>();
		windows.GetComponent<Explode> ().enabled = false;
		windows.GetComponent<Renderer> ().material = (Material)loadedMaterials [loadedMaterials.Length - 1];

		for (int i = 0; i < windowNames.Length; i++) {

			GameObject components = new GameObject (windowNames [i]);
			UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent (components, "", windowNames [i]);
			components.AddComponent<Backface> ();
			components.transform.SetParent (windows.transform);
		}
		#endregion

		#region Wheel mesh
		GameObject wheels = new GameObject ();
		wheels.name = "Wheels";
		transform.position = Vector3.zero;
		car.transform.rotation = Quaternion.identity;
		wheels.AddComponent<MeshFilter> ();
		wheels.AddComponent<MeshRenderer> ();
		wheels.AddComponent<CombineMeshes> ();
		wheels.GetComponent<CombineMeshes> ().enabled = false;
		wheels.AddComponent<ShowOffModel> ();
		wheels.GetComponent<ShowOffModel> ().enabled = false;
		wheels.AddComponent<Explode>();
		wheels.GetComponent<Explode> ().enabled = false;
		wheels.GetComponent<Renderer> ().material = (Material)loadedMaterials [loadedMaterials.Length - 2];
			
		for (int i = 0; i < wheelNames.Length; i++) {
			
			GameObject components = new GameObject (wheelNames [i]);
			UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent (components, "", wheelNames [i]);
			components.transform.SetParent (wheels.transform);
		}
		#endregion
	}
}
