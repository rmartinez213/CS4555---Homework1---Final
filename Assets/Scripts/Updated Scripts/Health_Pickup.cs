using UnityEngine;
using System.Collections;
public class Health_Pickup : MonoBehaviour
{
    public Transform other;
    public float closeDistance = 0.5F;


    void Update()
    {
        if (other)
        {
            Vector3 offset = other.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            if (sqrLen < closeDistance * closeDistance)
            {
                //Destroy static medkit object
                //Destroy(this.gameObject);
                this.gameObject.SetActive(false);

                //Create player object and call Increase function
                PlayerCharacter player = other.GetComponent<PlayerCharacter>();
                player.IncreaseHealth(3);
            }

        }
    }

    public void HealthReset()
    {
        this.gameObject.SetActive(true);
    }
}