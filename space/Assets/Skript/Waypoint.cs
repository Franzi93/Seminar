using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	public int _nummer;
	public bool _istPassiert = false;
	public bool _istDerNaechsteWp = false;
	public bool _istDerResetWp = false;
	public bool _istZiel = false;
	
	void Start() {

	}

	void OnTriggerEnter(Collider other) {

		if (_istDerNaechsteWp) 
		{
			_istPassiert = true;
			GetComponent<AudioSource>().Play();

			WayPointControl go_Wcontroler = GameObject.FindGameObjectWithTag("WaypointControler").GetComponent<WayPointControl>();
			go_Wcontroler._zuletztMarkierterWegpunkt_index = _nummer;
		}

		//Destroy(other.gameObject);
	}


	// Update is called once per frame
	void Update () {
	


		if(_istDerNaechsteWp)
		{
			Light li = GetComponent<Light>();
			if(li != null){li.color = Color.green;}
		}

		if (_istPassiert) {
			Light li = GetComponent<Light>();
			if(li != null){li.color = Color.yellow;}
			_istDerNaechsteWp = false;
		}
	}
}
