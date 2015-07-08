using UnityEngine;
using System.Collections;


public class HealthControl : MonoBehaviour {

	public float _Leben = 100.0F;

	void OnCollisionEnter(Collision collision) {
		_Leben = _Leben - 25;
		
		if(_Leben < 0f){
			Tot();
		}
		
	}

	void Update () {

		//GameObject GO_LebenSlider= GameObject.FindGameObjectWithTag ("LebenSlider");
		//if (GO_HUD != null) {
			//Slider jo =  GO_LebenSlider.GetComponent<Slider>();

			//GO_HUD.transform.position = transform.position;
			//GO_HUD.transform.rotation = transform.rotation;
		//}

	}

	public void Tot(){
		
		_Leben = 100f;
	}
}
