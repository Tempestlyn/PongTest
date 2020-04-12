using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public float speed = 10.0f;
	public float boundY = 2.25f;
	private Rigidbody2D m_rb2d;

    public GameObject ball;
    private BallController ballController;

 

	private void Start () 
	{
		m_rb2d = GetComponent<Rigidbody2D> ();
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballController = ball.GetComponent<BallController>();
	}
	
	private void Update () 
	{
		var vel = m_rb2d.velocity;
		
		if (Input.GetKey (moveUp)) 
		{
            
            vel.y = speed;
		} 
		else if (Input.GetKey (moveDown)) 
		{
			vel.y = -speed;
		} 
		else if (!Input.anyKey) 
		{
			vel.y = 0;
		}
		
		m_rb2d.velocity = vel;

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
}
