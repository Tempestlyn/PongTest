using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public float speed = 5.0f;
    public float boundY = 2.25f;
    public float moveY = 0;

    public string ballPos = "";
    public string lastBallPos = "";

    private bool isDelayed = false;

    private Rigidbody2D m_rb2d;

    


    public GameObject ball;
    private BallController ballController;

    // Start is called before the first frame update
    private void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballController = ball.GetComponent<BallController>();
    }

    private void Update()
    {


        if (ball.transform.position.y > transform.position.y)
        {   // checks to see if ball/lower is higher then AI player
            
            IsBallUP(true);

        }
        else if (ball.transform.position.y < transform.position.y)
        {
            IsBallUP(false);
            
        }



        var pos = transform.position;

        if (pos.y > boundY)
        {
            pos.y = boundY;
        }

        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }

        transform.position = pos;

        this.transform.position += new Vector3(0, moveY * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detects to see if paddle collides with ball, then checks point of collision in correlation to the paddle's height
        //paddle is divided into 5 segments, each with a different effect on the y transformation

        //|| Upper Tip
        //|| Upper
        //|| Middle
        //|| Lower
        //|| Lower Tip 


        if (collision.gameObject == ball)
        {

            float hitPoint = (collision.transform.position.y - this.transform.position.y) / this.transform.lossyScale.y;
            if (hitPoint >= -.15 && hitPoint <= .15)

            {
                //Middle
                IncreaseSpeed();
                ballController.moveX *= -1;

            }
            else if (hitPoint > .15 && hitPoint < .4)
            {
                //Upper
                IncreaseSpeed();
                ballController.moveX *= -1;
                ballController.moveY += 1f * ballController.ySpeed;

            }
            else if (hitPoint < -.15 && hitPoint > -.4)
            {
                //Lower
                IncreaseSpeed();
                ballController.moveX *= -1;
                ballController.moveY += -1f * ballController.ySpeed;

            }

            else if (hitPoint >= .4)
            {
                //Upper tip
                IncreaseSpeed();
                ballController.moveX *= -1;
                ballController.moveY += 1.5f * ballController.ySpeed;

            }
            else if (hitPoint <= -.4)
            {
                //Lower tip
                IncreaseSpeed();
                ballController.moveX *= -1;
                ballController.moveY += -1.5f * ballController.ySpeed;

            }

        }
    }

    private void IncreaseSpeed()
    {
        //Increases speed of both x and y transformations of the ball

        if (Mathf.Abs(ballController.moveX) < ballController.topSpeed)
        {
            ballController.moveX *= 1.25f;
        }
        if (ballController.ySpeed < ballController.topSpeed - 1)
        {
            ballController.ySpeed += 0.25f;
        }

    }

    IEnumerator Delay(string dir)
    {
        //acts as human-like reaction time
        //small delay before the paddle changes direction

        Debug.Log(ballPos);
        var delay = 0.1f;
        while (delay > 0)
        {
            delay--;
            yield return new WaitForSeconds(.1f);

        }
        Debug.Log("test");
        if (dir == "down")
        {
            moveY = -3.5f;
        }
        else
        {
            moveY = 3.5f;
        }

    }

    public void IsBallUP(bool dir)
    {
     //checks to see if ball changed from being higher to lower
     //if so, start delay coroutine
        if (dir == true)
        {
            
            ballPos = "up";
        }
        else
        {
            ballPos = "down";
        }
        if (ballPos != lastBallPos)
        {
           
            lastBallPos = ballPos;

            if (dir == true)
            {
                
                StartCoroutine(Delay("up"));
            }
            else
            {

                StartCoroutine(Delay("down"));
            }
        }
        
    }
}
