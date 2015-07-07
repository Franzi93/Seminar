using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	private GameObject _go_SelectPL_Erde;
	private GameObject _go_SelectPL_Lava;
	private int _planet_index;


	void OnMouseDown() {
		Application.LoadLevel(_planet_index);
	}

	void OnMouseOver() {

		transform.Rotate (0, Time.deltaTime * 20f, 0); // Rotieren des PL
		transform.GetComponent<Light> ().intensity = 8f; //Highlight PL

		if (transform.tag == "SelectPL_Erde") {_planet_index = 1;}
		if (transform.tag == "SelectPL_Lava") {_planet_index = 2;} 

	}

	void OnMouseExit() {
		transform.GetComponent<Light> ().intensity = 0f;
	}
}
