using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	public int _health;

	void Start() {
		_health = 5;
	}

	public void Hurt(int damage) {
		_health -= damage;
        
		if(_health == 0){
			Debug.Log("You are dead!");
		}
		else{
			Debug.Log("Health: " + _health);
		}
	}

	public void IncreaseHealth(int healthIncrease){
		_health += healthIncrease;
		Debug.Log("Your health has increased by: " + healthIncrease + ". New health is: " + _health);
	}
}
