using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	private GameObject _go_SelectPL_Erde;
	private GameObject _go_SelectPL_Lava;
	private int _planet_index;

	void Start() {

	}

	void OnMouseDown() {
		Application.LoadLevel(_planet_index);
	}

	void OnMouseOver() {

		transform.Rotate (0, Time.deltaTime * 20f, 0);
		if (transform.tag == "SelectPL_Erde") {_planet_index = 1;}
		if (transform.tag == "SelectPL_Lava") {_planet_index = 2;} 

	}
	
}
