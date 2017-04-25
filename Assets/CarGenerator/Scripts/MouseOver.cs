using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public GameObject[] text;

	void Start () {

		for (int i = 0; i < text.Length; i++) {
			text [i].SetActive (false);
		}
	}

	public void OnPointerEnter (PointerEventData eventData) {

		if (gameObject.name == "NewButton") {
			text [0].SetActive (true);
		} else if (gameObject.name == "CombineMeshButton") {
			text [1].SetActive (true);
		} else if (gameObject.name == "SaveForUnityButton") {
			text [2].SetActive (true);
		} else if (gameObject.name == "SaveForOtherButton") {
			text [3].SetActive (true);
		} else if (gameObject.name == "ExportWindowsButtonUnity") {
			text [4].SetActive (true);
		} else if (gameObject.name == "ExportWindowsButtonOBJ") {
			text [5].SetActive (true);
		} else if (gameObject.name == "ExportWheelsButtonUnity") {
			text [6].SetActive (true);
		} else if (gameObject.name == "ExportWheelsButtonOBJ") {
			text [7].SetActive (true);
		}  else if (gameObject.name == "QuickExportUnity") {
			text [8].SetActive (true);
		}  else if (gameObject.name == "QuickExportObj") {
			text [9].SetActive (true);
		}
	}

	public void OnPointerExit (PointerEventData eventData) {

		for (int i = 0; i < text.Length; i++) {
			text [i].SetActive (false);
		}
	}
}
