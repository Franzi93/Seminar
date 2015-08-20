/**
 * Bewegung des spielers per Maus und Tastatur
 */
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class SpielerBewegung : NetworkBehaviour
{
	public float maxBeschleunigung;
	public float minBeschleunigung;
	public float rotationBeschleunigung;
	public bool status;
	
	public float momentaneBeschleunigung = 1f;
	private GameObject[] turbines;
	
	void Start(){
		turbines = GameObject.FindGameObjectsWithTag("Turbine");
		status = true;
	}
	
	void FixedUpdate()
	{

		//Staus == Pause, Start
		if (status){

			//Rotation manager
			if (Input.GetKey(KeyCode.A))
				transform.Rotate(0, 0, Time.deltaTime * rotationBeschleunigung);
			else if (Input.GetKey(KeyCode.D))
				transform.Rotate(0, 0, -Time.deltaTime * rotationBeschleunigung);
			
			//Beschleunigen
			if (Input.GetKey(KeyCode.W))
			{
				
				while(Input.GetKey(KeyCode.W) 
			      && maxBeschleunigung >= momentaneBeschleunigung)
				{

					momentaneBeschleunigung = momentaneBeschleunigung + 0.001f;
				}
				
			}//Abbremmsen
			else if (Input.GetKey(KeyCode.S))
			{
				
				while(Input.GetKey(KeyCode.S) 
			      && minBeschleunigung <= momentaneBeschleunigung)
				{

					momentaneBeschleunigung = momentaneBeschleunigung * -1f;
				}
				

			}//Verlangsamen
			else
			{

				while(minBeschleunigung < momentaneBeschleunigung)
				{
					momentaneBeschleunigung = momentaneBeschleunigung - 0.001f;
				}
				
			}


			MaxTurbines(momentaneBeschleunigung * 0.002f);

			Vector3 MausBewegung = (Input.mousePosition - (new Vector3(Screen.width/ 2.0f, Screen.height/ 2.0f, 0) )) * 0.3f;
			transform.Rotate(new Vector3(-MausBewegung.y, MausBewegung.x, -MausBewegung.x) * 0.025f);

			Rigidbody r = GetComponent<Rigidbody>();
			if (r != null) {r.AddForce (transform.forward * momentaneBeschleunigung, ForceMode.Impulse);}	

		} 
	}
	
	void MaxTurbines(float intensity){

		foreach (GameObject turbine in turbines)
		{
			//Debug.Log("Hello");
			if(intensity > 0.3f){intensity = 0.3f;}
			turbine.GetComponent<LensFlare>().brightness = intensity;
		}
	}
	
}

