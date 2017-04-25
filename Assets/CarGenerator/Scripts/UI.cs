using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityExtension;

public class UI : MonoBehaviour {

	public GameObject[] button;
	public GameObject successObj;
	public GameObject toggleRotateButton;
	public GameObject toggleExplodeButton;
	public GameObject quickExportUnityButton;
	public GameObject quickExportObjButton;

	int id;

	void Start () {

		//Ensure that all the buttons are hidden just in case
		for (int i = 0; i < button.Length; i++) {
			button [i].SetActive (false);
			successObj.SetActive (false);
			toggleRotateButton.SetActive (false);
			toggleExplodeButton.SetActive (false);
			quickExportUnityButton.SetActive (false);
			quickExportObjButton.SetActive (false);
		}

		//Enable the NEW button, COMBINE MESH button, TOGGLE ROTATE button and TOGGLE POP button
		button [0].SetActive (true);
		button [3].SetActive (true);
		toggleRotateButton.SetActive (true);
		toggleExplodeButton.SetActive (true);

		id = FindObjectOfType<Seed> ().seed;
	}

	#region Reload the scene
	public void NewButton () {

		//Re-load the scene to start the generation again
		SceneManager.LoadScene (0);
	}
	#endregion

	#region Combine all the meshes
	public void CombineMesh () {

		//Enable the scripts so that is can combine the meshes
		GameObject.Find("Car").GetComponent<CombineMeshes> ().enabled = true;
		GameObject.Find("Windows").GetComponent<CombineMeshes> ().enabled = true;
		GameObject.Find("Wheels").GetComponent<CombineMeshes> ().enabled = true;

		quickExportUnityButton.SetActive (true);
		quickExportObjButton.SetActive (true);

		//Set the second batch of button to visible
		for (int i = 0; i < button.Length; i++) {
			button [i].SetActive (true);
		}

		//Hide this button
		button [3].SetActive (false);

		//Hide the toggle rotate button
		toggleRotateButton.SetActive (false);
		toggleExplodeButton.SetActive (false);

		//Get the ShowOffModel script from 3 different objects to find in the scene
//		ShowOffModel[] rotateMeshes = new ShowOffModel[3] {
//
//			GameObject.Find ("Car").GetComponent<ShowOffModel> (),
//			GameObject.Find ("Windows").GetComponent<ShowOffModel> (),
//			GameObject.Find ("Wheels").GetComponent<ShowOffModel> ()
//		};

		ShowOffModel[] rotateMeshes = FindObjectsOfType<ShowOffModel> ();

		//Disable the scripts and reset the car/windows positions/rotations
		for (int i = 0; i < rotateMeshes.Length; i++) {
			
			rotateMeshes [i].enabled = false;
			rotateMeshes [i].transform.position = Vector3.zero;
			rotateMeshes [i].transform.rotation = Quaternion.identity;
		}
	}
	#endregion

	#region Export car as asset
	public void SaveForUnityButton ()  {

		//Get the mesh filter component from the car and assign it's mesh
		MeshFilter meshFilter = GameObject.Find("Car").GetComponent<MeshFilter> ();
		Mesh mesh = meshFilter.mesh;

		//Open the [Save as..] panel from your OS
		string path = EditorUtility.SaveFilePanel("Save as .asset", "Assets/", mesh.name + id, "asset");

		//Stop errors from happening if the user cancels the save process
		if (string.IsNullOrEmpty (path)) {

			return;
		}

		//Get the new path and info if the user changes them
		path = FileUtil.GetProjectRelativePath(path);

		//Create the asset file from the car mesh in the given path and then save it
		AssetDatabase.CreateAsset(mesh, path);
		AssetDatabase.SaveAssets();
	}
	#endregion

	#region Export car as obj
	public void SaveForOtherButton () {

		//Get the mesh filter component from the car model
		MeshFilter meshFilter = GameObject.Find("Car").GetComponent<MeshFilter> ();

		//Open the [Save as..] panel from your OS
		var path = EditorUtility.SaveFilePanel ("Save as .obj", "Assets/", meshFilter.name + id + ".obj", "obj");

		//Stop errors from happening if the user cancels the save process
		if (string.IsNullOrEmpty (path)) {

			return;
		}

		//Create a file stream that will take the path from the OS and open in create mode
		FileStream fileStream = new FileStream (path, FileMode.Create);

		//The obj data contained resulting from the encode obj function
		OBJData objData = meshFilter.sharedMesh.EncodeOBJ ();

		//Calling the export obj function taking the obj data and the file stream and close it
		OBJLoader.ExportOBJ (objData, fileStream);
		fileStream.Close ();

		//Display some comfirmation text to the screen then call the ienumerator
		successObj.SetActive (true);
		StartCoroutine (HideTextAfterTime (3.0f));
	}
	#endregion

	#region Export windows as asset
	public void ExportWindowsForUnity () {
		
		//Get the mesh filter component from the windows and assign it's mesh
		MeshFilter meshFilter = GameObject.Find("Windows").GetComponent<MeshFilter> ();
		Mesh mesh = meshFilter.mesh;

		//Open the [Save as..] panel from your OS
		string path = EditorUtility.SaveFilePanel("Save as .asset", "Assets/", mesh.name + id, "asset");

		//Stop errors from happening if the user cancels the save process
		if (string.IsNullOrEmpty (path)) {

			return;
		}

		//Get the new path and info if the user changes them
		path = FileUtil.GetProjectRelativePath(path);

		//Create the asset file from the car mesh in the given path and then save it
		AssetDatabase.CreateAsset(mesh, path);
		AssetDatabase.SaveAssets();
	}
	#endregion

	#region Export windows as obj
	public void ExportWindowsForOther() {
		
		//Get the mesh filter component from the car model
		MeshFilter meshFilter = GameObject.Find("Windows").GetComponent<MeshFilter> ();

		//Open the [Save as..] panel from your OS
		var path = EditorUtility.SaveFilePanel ("Save as .obj", "Assets/", meshFilter.name + id + ".obj", "obj");

		//Stop errors from happening if the user cancels the save process
		if (string.IsNullOrEmpty (path)) {

			return;
		}

		//Create a file stream that will take the path from the OS and open in create mode
		FileStream fileStream = new FileStream (path, FileMode.Create);

		//The obj data contained resulting from the encode obj function
		OBJData objData = meshFilter.sharedMesh.EncodeOBJ ();

		//Calling the export obj function taking the obj data and the file stream and close it
		OBJLoader.ExportOBJ (objData, fileStream);
		fileStream.Close ();

		//Display some comfirmation text to the screen then call the ienumerator
		successObj.SetActive (true);
		StartCoroutine (HideTextAfterTime (3.0f));
	}
	#endregion

	#region Export wheels as asset
	public void ExportWheelsForUnity () {

		//Get the mesh filter component from the windows and assign it's mesh
		MeshFilter meshFilter = GameObject.Find("Wheels").GetComponent<MeshFilter> ();
		Mesh mesh = meshFilter.mesh;

		//Open the [Save as..] panel from your OS
		string path = EditorUtility.SaveFilePanel("Save as .asset", "Assets/", mesh.name + id, "asset");

		//Stop errors from happening if the user cancels the save process
		if (string.IsNullOrEmpty (path)) {

			return;
		}

		//Get the new path and info if the user changes them
		path = FileUtil.GetProjectRelativePath(path);

		//Create the asset file from the car mesh in the given path and then save it
		AssetDatabase.CreateAsset(mesh, path);
		AssetDatabase.SaveAssets();
	}
	#endregion

	#region Export windows as obj
	public void ExportWheelsForOther() {

		//Get the mesh filter component from the car model
		MeshFilter meshFilter = GameObject.Find("Wheels").GetComponent<MeshFilter> ();

		//Open the [Save as..] panel from your OS
		var path = EditorUtility.SaveFilePanel ("Save as .obj", "Assets/", meshFilter.name + id + ".obj", "obj");

		//Stop errors from happening if the user cancels the save process
		if (string.IsNullOrEmpty (path)) {

			return;
		}

		//Create a file stream that will take the path from the OS and open in create mode
		FileStream fileStream = new FileStream (path, FileMode.Create);

		//The obj data contained resulting from the encode obj function
		OBJData objData = meshFilter.sharedMesh.EncodeOBJ ();

		//Calling the export obj function taking the obj data and the file stream and close it
		OBJLoader.ExportOBJ (objData, fileStream);
		fileStream.Close ();

		//Display some comfirmation text to the screen then call the ienumerator
		successObj.SetActive (true);
		StartCoroutine (HideTextAfterTime (3.0f));
	}
	#endregion

	#region Quick export as asset
	public void QuickExportUnity () {

		SaveForUnityButton ();
		ExportWheelsForUnity ();
		ExportWindowsForUnity ();

	}
	#endregion

	#region Quick export as obj
	public void QuickExportObj () {
		
		SaveForOtherButton ();
		ExportWheelsForOther ();
		ExportWindowsForOther ();
	}
	#endregion


	#region Hide exported obj text
	IEnumerator HideTextAfterTime (float time) {

		//After some amount of time, hide the text
		yield return new WaitForSeconds (time);
		successObj.SetActive (false);
	}
	#endregion

	#region Stop the editor from playing
	public void StopEditorFromPlayer () {

		//Stop the editor from playing
		UnityEditor.EditorApplication.isPlaying = false;
	}
	#endregion

	#region Rotate the model on the spot
	public void ShowOffTheModel () {

		//Get the ShowOffModel script from 3 different objects to find in the scene
		ShowOffModel[] rotateMeshes = FindObjectsOfType<ShowOffModel> ();

		//Turn on all of those ShowOffModel scripts to be the inverse of it's current state. If true and button click then false, vise versa
		for (int i = 0; i < rotateMeshes.Length; i++) {
			
			rotateMeshes [i].enabled = !rotateMeshes [i].isActiveAndEnabled;
			FindObjectsOfType<Explode> () [i].enabled = false;
			toggleExplodeButton.SetActive (!toggleExplodeButton.activeSelf);
		}

		//When the button is clicked, if the script is not enabled, then reset the rotation and position
		if (rotateMeshes[0].isActiveAndEnabled == false) {

			for (int i = 0; i < rotateMeshes.Length; i++) {

				rotateMeshes [i].transform.position = Vector3.zero;
				rotateMeshes [i].transform.rotation = Quaternion.identity;
			}
		}
	}
	#endregion

	#region Make all of the meshes go outwards
	public void ToggleExplode () {

		button[3].SetActive (!button[3].activeSelf);


		Explode[] explode = FindObjectsOfType<Explode> ();

		for (int i = 0; i < explode.Length; i++) {
			explode[i].enabled = true;

			if (explode[i].popOut) {
				explode[i].timer = 0.0f;
				explode[i].travelTime = 1f;
				explode[i].popOut = false;
			} else {
				explode[i].timer = 0.0f;
				explode[i].travelTime = 50f;
				explode[i].popOut = true;
			}
		}
	}
	#endregion
}
