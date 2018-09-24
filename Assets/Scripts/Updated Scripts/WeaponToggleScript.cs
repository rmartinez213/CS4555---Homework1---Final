using UnityEngine;

public class WeaponToggleScript : MonoBehaviour {

	public int currentWeapon = 0;

	void Start () {
		selectWeapon();
	}

	void Update(){

		int previousWeapon = currentWeapon;

        //Selects shotgun
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			currentWeapon = 0;
		}

        //Selects AK-47
		if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
       
        
        //Calls select weapon function go implement changes
		if(previousWeapon != currentWeapon){
			selectWeapon();
		}

	}

	void selectWeapon(){

		//Used to incrememnt weapon value (for switching)
		int i = 0;

		foreach(Transform weapon in transform){

			if (i == currentWeapon)
				weapon.gameObject.SetActive(true);
			else
				weapon.gameObject.SetActive(false);
			
			i++;
		}
	}
}
