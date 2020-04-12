using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public float speed = 10.0f;
	public float boundY = 2.25f;
	private Rigidbody2D m_rb2d;

	private void Start () 
	{
		m_rb2d = GetComponent<Rigidbody2D> ();
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
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Test");
            float hitPoint = (collision.transform.position.y - this.transform.position.y) / this.transform.lossyScale.y;
            Debug.Log(hitPoint);
            if (hitPoint >= -.25 && hitPoint <= .25)
            {
                collision.GetComponent<BallController>().moveX *= -1;
                
                Debug.Log(hitPoint);
            }
            else if (hitPoint > .25 && hitPoint < .4)
            {
                collision.GetComponent<BallController>().moveX *= -1;
                collision.GetComponent<BallController>().moveY += 1f;
            }
            else if (hitPoint < -.25 && hitPoint > -.4)
            {
                collision.GetComponent<BallController>().moveX *= -1;
                collision.GetComponent<BallController>().moveY += -1f;
            }
            //collision.gameObject.GetComponent<BallController>().movement = Vector2.right; 
            else if (hitPoint >= .4)
            {
                collision.GetComponent<BallController>().moveX *= -1;
                collision.GetComponent<BallController>().moveY += 1.5f;
            }
            else if (hitPoint <= -.4)
            {
                collision.GetComponent<BallController>().moveX *= -1;
                collision.GetComponent<BallController>().moveY += -1.5f;
            }

        }
    }
}
