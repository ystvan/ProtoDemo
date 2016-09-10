using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    Vector3 Move;
    float CamWidthX = 6.1f;
    float CamHeightY = 3.3f;
    float Speed = 0.09f;

    float LeftEdge;
    float RightEdge;
    float BottomEdge;
    float TopEdge;

    float Teleport;
    public int CoolCounter;

    void Start()
    {
        Move = transform.position;

        LeftEdge = CamWidthX*-1;
        RightEdge = CamWidthX;
        BottomEdge = CamHeightY*-1;
        TopEdge = CamHeightY;


    }

     void Update()
    {
        //Teleport
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CoolCounter == 0)
            {
                Teleport = 2f;
                CoolCounter = 100;
            }
            
        }
        else
        {
            Teleport = 0;
        }

        CoolCounter--;

        if (CoolCounter < 0)
        {
            CoolCounter = 0;
        }

        //Movement
        if (Input.GetKey(KeyCode.LeftArrow))
            Move.x -= Speed + Teleport;
        if (Input.GetKey(KeyCode.RightArrow))
            Move.x += Speed + Teleport;
        if (Input.GetKey(KeyCode.UpArrow))
            Move.y += Speed + Teleport;
        if (Input.GetKey(KeyCode.DownArrow))
            Move.y -= Speed + Teleport;

        transform.position = Move;
    }

    void LateUpdate()
    {
        //Check if at the edge of screen and constraint movement is reached

        if (transform.position.x < LeftEdge)
            Move.x = LeftEdge;
        if (transform.position.x > RightEdge)
            Move.x = RightEdge;
        if (transform.position.y < BottomEdge)
            Move.y = BottomEdge;
        if (transform.position.y > TopEdge)
            Move.y = TopEdge;

        transform.position = Move;
    }

}