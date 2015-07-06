using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	public bool _passiert = false;

	void Start() {

	}

	void OnTriggerEnter(Collider other) {
		_passiert = true;
		Light li = GetComponent<Light>();
		if(li != null)	{li.color = Color.green;}
		//Destroy(other.gameObject);
	}


	// Update is called once per frame
	void Update () {
	
		if (_passiert) {
			Light li = GameObject.FindGameObjectWithTag("WaypointLight").GetComponent<Light>();
			if(li != null){li.color = Color.green;}
		}
	}
}
