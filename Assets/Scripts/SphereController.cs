using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour
{
    GameObject CubeReference;
    Vector3 CubereRefPosition;
    float Speed = 0.08f;
    public Vector2 Distance;

    public int Timer;
    Vector3 RandomSpawn;

    
    void Start()
    {
        //Reference to our Cube/Player1 GameObject
        CubeReference = GameObject.Find("Cube");
        Timer = 1;
    }

    void Update()
    {
        //Sphere Tracks position of Player1 and follows
        CubereRefPosition = CubeReference.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, CubereRefPosition, Speed);

        //Check Distance between player1 & Enemy
        Distance.x = transform.position.x - CubereRefPosition.x;
        Distance.y = transform.position.y - CubereRefPosition.y;

        //If Occupying the same space as you, you've been eaten!!!

        if (((Distance.x < 0.1f) && (Distance.x > -0.1f)) && ((Distance.y < 0.1f) && (Distance.y > -0.1f)))
        {
            GameObject.Destroy(CubeReference);
            Debug.Log("You have been eaten!!!");
        }

        //Spawn dublicates every 500 ticks
        if (Timer % 500 == 0)
        {
            RandomSpawn.x = Random.Range(-6.1f, 6.1f);
            RandomSpawn.y = Random.Range(-3.3f, 3.3f);
            RandomSpawn.z = transform.position.z;
            GameObject.Instantiate(this.gameObject, RandomSpawn, transform.rotation);

        }
        Timer++;

    }

}