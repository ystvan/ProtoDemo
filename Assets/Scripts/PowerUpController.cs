using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour
{

    GameObject CubeReference;

    
    public int Timer = 1;

	void Start()
	{
        CubeReference = GameObject.Find("Cube");
	    
	}

	void Update()
	{
        DestroyPowerUp();
    }

    private bool AtePowerUp()
    {
        //Eat or destroy PowerUp

        Vector2 distance = new Vector2(
            transform.position.x - CubeReference.transform.position.x,
            transform.position.y - CubeReference.transform.position.y
        );


        //Determines wheter or not Cube is near the PowerUp ( some leniency within 0.5 units)

        if (((distance.x < 0.5f) && (distance.x > -0.5f)) && ((distance.y < 0.5f) && (distance.y > -0.5f)))
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DestroyPowerUp()
    {
        Timer++;

        if (AtePowerUp())
        {
            GameObject.Destroy(gameObject);
            PowerUpManager.PowerUpMeter += 100;
            Debug.Log(PowerUpManager.PowerUpMeter);
        }

        if (Timer % 140 == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}