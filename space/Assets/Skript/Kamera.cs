using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {

	private bool _FirstPersonStatus = false;
	public GameObject _1cam;
	public GameObject _3cam;


	void Update () {
			if (Input.GetKeyDown (KeyCode.C)) {
			SwitchSchaltung();
		}
		

	}

	void SwitchSchaltung()
	{
		_3cam.SetActive (_FirstPersonStatus);
		_1cam.SetActive (!_FirstPersonStatus);
		
		_FirstPersonStatus=!_FirstPersonStatus;
	}
	






}
