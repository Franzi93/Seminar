using UnityEngine;
using System.Collections;

public class enemynav : MonoBehaviour {
	public GameObject dest;
	private NavMeshAgent agent;
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (dest.transform.position);
	}
	

}
