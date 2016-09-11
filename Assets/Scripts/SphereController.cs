using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour
{
    public GameObject CubeReference;
    
    float Speed = 0.08f;
    
    Vector3 CubereRefPosition;

    public int Timer;
    

    
    void Start()
    {
        //Reference to our Cube/Player1 GameObject
        CubeReference = GameObject.Find("Cube");
        Timer = 1;
    }

    void Update()
    {
        Movement();
        SpawnEnemy();
        EnemyProximity();
    }

    private void Movement()
    {
        //Sphere Tracks position of Player1 and follows
        CubereRefPosition = CubeReference.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, CubereRefPosition, Speed);
    }
    private void EnemyProximity()
    {
        

        //Check Distance between player1 & Enemy
        float x = transform.position.x - CubereRefPosition.x;
        float y = transform.position.y - CubereRefPosition.y;
        Vector2 distance = new Vector2(x,y);

        //If Occupying the same space as you, you've been eaten!!!

        if (((distance.x < 0.1f) && (distance.x > -0.1f)) && ((distance.y < 0.1f) && (distance.y > -0.1f)))
        {
            GameObject.Destroy(CubeReference);
            Debug.Log("You have been eaten!!!");
        }
    }
    private void SpawnEnemy()
    {
        //Spawn dublicates every 500 ticks
        if (Timer % 500 == 0)
        {
            
            float x = Random.Range(-6.1f, 6.1f);
            float y = Random.Range(-3.3f, 3.3f);
            float z = transform.position.z;
            GameObject.Instantiate(this.gameObject, new Vector3(x, y, z), transform.rotation);

        }
        Timer++;
    }

}