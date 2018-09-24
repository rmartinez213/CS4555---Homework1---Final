using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public Transform[] portals;
	int Portal_index;


	void OnTriggerEnter(Collider Player){
		Portal_index = Random.Range(0, portals.Length);
		Player.transform.position = portals[Portal_index].position;
		Debug.Log(Portal_index);
	}
}
