using UnityEngine;
using System.Collections;

public class WayPointControl : MonoBehaviour {

	public GameObject[] _waypoints;
	public int _zuletztMarkierterWegpunkt_index;
	public bool _alleWegpunktePassiert;


	// Use this for initialization
	void Start () {
		_alleWegpunktePassiert = false;
		_waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
	}

	void OnGUI() {
		
		float _ZeitSecSpielstart = Time.realtimeSinceStartup;
		string ToEdit = GUI.TextField(new Rect(10, 10, 100, 20),"Time: " + _ZeitSecSpielstart.ToString(), 25);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log("TEST");
		//Debug.LogFormat("Time.deltaTime:  {0} ", Time.deltaTime);

		int naechsterWegpunktIndex = _zuletztMarkierterWegpunkt_index + 1;

		foreach (GameObject go_wp in _waypoints)
		{
			Waypoint wp = go_wp.GetComponent<Waypoint>();
			wp._istDerResetWp = false;

			if(naechsterWegpunktIndex == go_wp.GetComponent<Waypoint>()._nummer)
			{
				wp._istDerNaechsteWp = true; // Festlegen des nächsten Wegpunkts
			}

			if(_zuletztMarkierterWegpunkt_index == go_wp.GetComponent<Waypoint>()._nummer)
			{
				wp._istDerResetWp = true; // Festlegen des Punktes auf den der Spieler bei Tot zuück gesetzt wird.
			}

			if(wp._istZiel && wp._istPassiert)
			{
				_alleWegpunktePassiert = true; // Flag ob alle Wegpunkte durchlaufen wurden ( implizites Ende des Spiels)
			}	
		} // .. foreach (GameObject go_wp in _waypoints)

		//float secSpielstart = Time.realtimeSinceStartup;
		//Debug.Log("SEKUNDEN: " + secSpielstart.ToString());


		// Spielende
		if(_alleWegpunktePassiert)
		{
			//float secSpielende = Time.unscaledTime;
			//Debug.Log("SEKUNDEN_secSpiel: " + secSpielende.ToString());

			//if(secSpielende * 100 > 4f)
			{
				Application.LoadLevel(0);// Laden des Level-Select-Menüs
			}
		}
	}// .. void Update () 
}
