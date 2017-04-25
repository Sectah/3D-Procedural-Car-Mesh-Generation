using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOffModel : MonoBehaviour {

	CreateCar createCar;
	Underside basicBottom;
	Classic9Bottom classicBottom;
	Van13Underside vanBottom;
	private float angle = 40;
	private Vector3 centerPoint;
	private Vector3 width;
	private Vector3 length;

	void Update () {

		if (!GameObject.Find ("Car").GetComponent<CombineMeshes> ().isActiveAndEnabled) {

			createCar = GameObject.FindObjectOfType<CreateCar> ();

			if (createCar.model == CreateCar.Model.Basic) {
		
				basicBottom = GameObject.Find ("Underside").GetComponent<Underside> ();
				width = Vector3.Lerp (basicBottom.mesh.vertices [0], basicBottom.mesh.vertices [1], 0.5f);
				length = Vector3.Lerp (basicBottom.mesh.vertices [1], basicBottom.mesh.vertices [3], 0.5f);

			} else if (createCar.model == CreateCar.Model.Classic) {
		
				classicBottom = GameObject.Find ("Classic9Bottom").GetComponent<Classic9Bottom> ();
				width = Vector3.Lerp (classicBottom.mesh.vertices [0], classicBottom.mesh.vertices [1], 0.5f);
				length = Vector3.Lerp (classicBottom.mesh.vertices [1], classicBottom.mesh.vertices [3], 0.5f);

			}  else if (createCar.model == CreateCar.Model.Van) {

				vanBottom = GameObject.Find ("Van13Underside").GetComponent<Van13Underside> ();
				width = Vector3.Lerp (vanBottom.mesh.vertices [0], vanBottom.mesh.vertices [1], 0.5f);
				length = Vector3.Lerp (vanBottom.mesh.vertices [1], vanBottom.mesh.vertices [3], 0.5f);
			}

			centerPoint = new Vector3 (width.x, 0, length.z);
			gameObject.transform.RotateAround (centerPoint, Vector3.up, angle * Time.deltaTime);
		}
	}
}
