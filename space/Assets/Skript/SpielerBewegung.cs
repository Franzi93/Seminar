/**
 * Bewegung des spielers per Maus und Tastatur
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpielerBewegung : MonoBehaviour
{
	public float maxGeschwindigkeit = 99f;
	public float minGeschwindigkeit = 1f;
	public float force = 0f;
	public float rotationGeschwindigkeit = 100f;
	public bool status = false;
	
	public float momentaneGeschwindigkeit = 1f;
	private GameObject[] turbines;
	
	void Start(){
		turbines = GameObject.FindGameObjectsWithTag("Turbine");
	}
	
	void LateUpdate()
	{
		//Staus == Pause, Start
		//if (status){
			//Rotation manager
			if (Input.GetKey(KeyCode.A))
				transform.Rotate(0, 0, Time.deltaTime * rotationGeschwindigkeit);
			else if (Input.GetKey(KeyCode.D))
				transform.Rotate(0, 0, -Time.deltaTime * rotationGeschwindigkeit);
			
			//Beschleunigen
			if (Input.GetKey(KeyCode.W))
			{
				
				while(Input.GetKey(KeyCode.W) 
			      && maxGeschwindigkeit >= momentaneGeschwindigkeit)
				{

					momentaneGeschwindigkeit = momentaneGeschwindigkeit + 0.001f;
				}
				
			}//Abbremmsen
			else if (Input.GetKey(KeyCode.S))
			{
				
				while(Input.GetKey(KeyCode.S) 
			      && minGeschwindigkeit <= momentaneGeschwindigkeit)
				{

					momentaneGeschwindigkeit = momentaneGeschwindigkeit * -0.1f;
				}
				

			}//Verlangsamen
			else
			{

				while(minGeschwindigkeit < momentaneGeschwindigkeit)
				{
					momentaneGeschwindigkeit = momentaneGeschwindigkeit - 0.001f;
				}
				
			}


			MaxTurbines(momentaneGeschwindigkeit);

			Vector3 MausBewegung = (Input.mousePosition - (new Vector3(Screen.width/ 2.0f, Screen.height/ 2.0f, 0) )) * 0.3f;
			transform.Rotate(new Vector3(-MausBewegung.y, MausBewegung.x, -MausBewegung.x) * 0.025f);

			Rigidbody r = GetComponent<Rigidbody>();
			
			if (r != null) {
				r.AddForce (transform.forward * momentaneGeschwindigkeit, ForceMode.Impulse);
			}	
			
			//transform.Translate(Vector3.forward * Time.deltaTime * momentaneGeschwindigkeit);

		//}
	}
	
	void MaxTurbines(float intensity){

		foreach (GameObject turbine in turbines)
		{
			turbine.GetComponent<LensFlare>().brightness = intensity * 0.002f;
		}
	}
	
}

