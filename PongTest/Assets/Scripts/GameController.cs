using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static int score1;
    public static int score2;

    public GameObject score1Object;
    public GameObject score2Object;

    public GameObject ball;
    private BallController ballController;



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
        //Updates score and score text, then resets ball speed and position, then randomizes the direction the ball 

        score1 += 1;
        score1Object.GetComponent<Text>().text = score1.ToString();
        ballController.ySpeed = 0;
        ballController.moveY = Random.Range(-1.0f, 1.0f);
        ballController.transform.position = new Vector3(0, 0, 0);
        ballController.moveX = -2;

    }
    public void Score2()
    {
        //Updates score and score text, then resets ball speed and position, then randomizes the direction the ball 

        score2 += 1;
        score2Object.GetComponent<Text>().text = score2.ToString();
        ballController.ySpeed = 0;
        ballController.moveY = Random.Range(-1.0f, 1.0f);
        ballController.transform.position = new Vector3(0, 0, 0);
        ballController.moveX = 2;
    }

    

}
