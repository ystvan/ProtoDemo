using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    int Timer;
    public static int PowerUpMeter;

    public bool IsPowered;

    void Start()
    {
        IsPowered = false;
	    Timer = 1;
	    PowerUpMeter = 50; //Default bonus on start
	}

	void Update()
	{
        //Spawns PowerUp every 300 ticks
	    if (Timer % 300 == 0)
	    {
            Vector3 randomSpawn = new Vector3(
                Random.Range(-6.1f, 6.1f),
                Random.Range(-3.3f, 3.3f),
                transform.position.z
            );

            GameObject.Instantiate(PowerUpPrefab, randomSpawn, transform.rotation);
        }

	    if (Input.GetKeyDown(KeyCode.Z) && !IsPowered && PowerUpMeter >0)
	    {
            //Startup PowerUp Mode
            IsPowered = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && IsPowered)
	    {
            //Cancel PowerUp Mode
            IsPowered = false;
        }
	    if (IsPowered)
	    {
	        PowerUpMeter--;
	        if (PowerUpMeter == 0)
	        {
	            IsPowered = false;
	        }
            Debug.Log(PowerUpMeter);
	    }
	    Timer++;
	}
}