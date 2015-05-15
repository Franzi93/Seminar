/**
 * Bewegung des spielers per Maus und Tastatur
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement: MonoBehaviour
{
	public float maxGeschwindigkeit = 1f;
	public float minGeschwindigkeit = 0.0000001f;
	public float rotationGeschwindigkeit = 100f;
	public float mausGeschwindigkeit = 0.1f;
	public bool status = false;
	
	public float momentaneGeschwindigkeit = 0.001f;
	
	void Start(){
	}
	
	void LateUpdate()
	{
		//Staus == Pause, Start
		if (status){
			//Rotation manager
			if (Input.GetKey(KeyCode.A))
				transform.Rotate(0, 0, Time.deltaTime * rotationGeschwindigkeit);
			else if (Input.GetKey(KeyCode.D))
				transform.Rotate(0, 0, -Time.deltaTime * rotationGeschwindigkeit);
			
			//Beschleunigen
			if (Input.GetKey(KeyCode.W)){
				
				while(Input.GetKey(KeyCode.W) && maxGeschwindigkeit >= momentaneGeschwindigkeit){
					
					momentaneGeschwindigkeit = momentaneGeschwindigkeit + 0.001F;
				}
				

			}//Abbremmsen
			else if (Input.GetKey(KeyCode.S)){
				
				while(Input.GetKey(KeyCode.S) && minGeschwindigkeit <= momentaneGeschwindigkeit){
					
					momentaneGeschwindigkeit = momentaneGeschwindigkeit* -0.0001F;
				}
				

			}//Gesch. halten
			else{
				momentaneGeschwindigkeit = momentaneGeschwindigkeit ;

			}
			
			Vector3 MausBewegung= (Input.mousePosition - (new Vector3(Screen.width, Screen.height, 0) / 2.0f)) * mausGeschwindigkeit;
			transform.Rotate(new Vector3(-MausBewegung.y, MausBewegung.x, -MausBewegung.x) * 0.025f);
			transform.Translate(Vector3.forward * Time.deltaTime * momentaneGeschwindigkeit);
		}
	}
	

	
}

