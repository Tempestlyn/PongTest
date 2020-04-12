using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveX = 0;
    public float moveY = 0;
    public float topSpeed = 0.0f;

    private void Start()
    {
        moveX = -2;
    }

    private void Update( )
    {
        MoveBall( );
    }
    
    public void MoveBall( ) {

        if (gameObject.transform.position.y >= 3 || gameObject.transform.position.y <= -3)
        {
            moveY *= -1;

        }

        this.transform.position += new Vector3(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);

    }
}
