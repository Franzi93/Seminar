using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {

	private bool _FirstPersonStatus = false;

	void Start(){

	}
	
	void Update () {
		if (Input.anyKeyDown) {
			if (Input.GetKey (KeyCode.C) && !_FirstPersonStatus) {
				_FirstPersonStatus = true;
				
			} else if (Input.GetKey (KeyCode.C) && _FirstPersonStatus) {
				
				_FirstPersonStatus = false;
			}
		}

	}

	
	void LateUpdate(){

		GameObject go_FirstPersCam = GameObject.FindGameObjectWithTag("FirstPersCam");
		GameObject go_ThirdPesCam = GameObject.FindGameObjectWithTag("ThirdPesCam");

		if (!_FirstPersonStatus) {

			if(go_FirstPersCam != null){go_FirstPersCam.GetComponent<Camera>().enabled = false;}
			if(go_ThirdPesCam != null){go_ThirdPesCam.GetComponent<Camera>().enabled = true;}
			GameObject.FindGameObjectWithTag ("HUD_3Pers").GetComponent<Canvas>().enabled =true;
			GameObject.FindGameObjectWithTag ("HUD_1Pers").GetComponent<Canvas>().enabled =false;

		} else {

			if(go_FirstPersCam != null){go_FirstPersCam.GetComponent<Camera>().enabled = true;}
			if(go_ThirdPesCam != null){go_ThirdPesCam.GetComponent<Camera>().enabled = false;}
			GameObject.FindGameObjectWithTag ("HUD_3Pers").GetComponent<Canvas>().enabled =false;
			GameObject.FindGameObjectWithTag ("HUD_1Pers").GetComponent<Canvas>().enabled =true;
		}
	}





}
