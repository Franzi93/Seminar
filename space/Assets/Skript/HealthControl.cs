using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HealthControl : MonoBehaviour {

	public float _Leben = 100.0F;
	public GameObject go_Player;
	public GameObject[] GO_LebenSliders;
	public GameObject go_wp_control;

	// Use this for initialization
	void Start () {
		go_Player = GameObject.FindGameObjectWithTag ("Player");
		GO_LebenSliders = GameObject.FindGameObjectsWithTag ("LebenSlider");
		go_wp_control = GameObject.FindGameObjectWithTag ("WaypointControler");
	}

	void OnCollisionEnter(Collision collision) {
		_Leben = _Leben - 51;
	}

	void Update () {

		if (GO_LebenSliders != null) {

			// Es gibt zwei! 1PersCam und 3PersCam!
			foreach (GameObject GO_LebenSlider in GO_LebenSliders)
			{
				GO_LebenSlider.GetComponent<Slider>().value = _Leben;
			}
		}

		if(_Leben < 0f){Tot();}

	}
	
	public void Tot(){

		// Reset der Lebensenergie
		// Reset der Spieler-Position auf letzten Wegpunkt

		_Leben = 100f;
		if (go_Player != null) {

			WayPointControl wp_control = go_wp_control.GetComponent<WayPointControl>();
			Waypoint reset_wp; 
		
			if(wp_control != null){

				reset_wp = wp_control._waypoints[0].GetComponent<Waypoint>();

				foreach (GameObject go_aktueller_wp in wp_control._waypoints)
				{
					Waypoint aktueller_wp = go_aktueller_wp.GetComponent<Waypoint>();

					if(aktueller_wp._istDerResetWp)
					{
						reset_wp = aktueller_wp;
					}
				}

				if(reset_wp)//Zurück setzen auf den letzten Wegpunkt
				{
					go_Player.transform.position = reset_wp.transform.position;
					go_Player.transform.rotation = reset_wp.transform.rotation;
				}
			}
			
		}
	}
}
