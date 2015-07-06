using UnityEngine;
using System.Collections;

public class WayPointControl : MonoBehaviour {

	private GameObject[] _waypoints;
	public int _zuletztMarkierterWegpunkt_index;
	public bool _alleWegpunktePassiert;


	// Use this for initialization
	void Start () {
		_alleWegpunktePassiert = false;
		_waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
	}
	
	// Update is called once per frame
	void Update () 
	{

		int naechsterWegpunktIndex = _zuletztMarkierterWegpunkt_index + 1;

		foreach (GameObject go_wp in _waypoints)
		{
			Waypoint wp = go_wp.GetComponent<Waypoint>();

			if(naechsterWegpunktIndex == go_wp.GetComponent<Waypoint>()._nummer)
			{
				wp._istDerNaechsteWp = true;
			}

			if(wp._istZiel && wp._istPassiert)
			{
				_alleWegpunktePassiert = true;
			}	
		} // .. foreach (GameObject go_wp in _waypoints)


		if(_alleWegpunktePassiert && Time.deltaTime > 30f)
		{

			Application.LoadLevel(0);
		}
	}// .. void Update () 
}
