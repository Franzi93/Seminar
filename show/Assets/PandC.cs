using UnityEngine;
using System.Collections;

public class PandC : MonoBehaviour {
	private NavMeshAgent agent;
	// Use this for initialization
	void Awake () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			agent.SetDestination(hit.point);
		
		}
	}
}
