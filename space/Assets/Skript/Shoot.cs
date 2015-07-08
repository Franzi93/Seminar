using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;
	public float force = 800.0f;
	public float projectileLifeTime = 10f;
	public bool status;

	// Use this for initialization
	void Start () {
		status = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Hello");
		if (status) {

			if (Input.GetMouseButtonDown (0)) {
				//Debug.Log ("SCHUSS!!!");

				bulletPrefab = GameObject.FindGameObjectsWithTag ("SchussLaser") [0];
				GameObject go = GameObject.Instantiate (bulletPrefab, transform.position + transform.forward * 5, Quaternion.identity) as GameObject;

				if (go != null) {
					//only happens if cast succeeded
					Rigidbody r = go.GetComponent<Rigidbody> ();
					if (r != null) {
						//Debug.Log ("BOOOM");

						Light li = go.GetComponent<Light> ();
						if (li != null) {
							li.intensity = 5f;
						}

						r.AddForce (transform.forward * force, ForceMode.Impulse);
					}
					
					Destroy (go, projectileLifeTime);
				}
			} else {
				GameObject GO_Spieler = GameObject.FindGameObjectsWithTag ("Player") [0];
				if (GO_Spieler != null) {
					transform.position = GO_Spieler.transform.position;
					transform.rotation = GO_Spieler.transform.rotation;
				}
			}

		} // -- if (status) {
	}
}
