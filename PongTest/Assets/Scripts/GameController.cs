using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int score1;
    public static int score2;

    public GameObject ball;
    private BallController ballController;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballController = ball.GetComponent<BallController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score1()
    {
        score1 += 1;
        ballController.moveY = 0;
        ballController.ySpeed = 0;
        ballController.transform.position = new Vector3(0, 0, 0);
        ballController.moveX = -2;

    }
    public void Score2()
    {
        score2 += 1;
        ballController.moveY = 0;
        ballController.ySpeed = 0;
        ballController.transform.position = new Vector3(0, 0, 0);
        ballController.moveX = 2;
    }


}
