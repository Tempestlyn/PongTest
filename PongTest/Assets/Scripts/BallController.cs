using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveX = -2;
    public float moveY = 0;
    public float topSpeed = 5.0f;
    public float ySpeed = 1;

    public GameObject gameControllerObject;
    public GameController gameController;

    private void Start()
    {
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        
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

        if (gameObject.transform.position.x < -5.2)
        {
            gameController.Score2();
        }

        if (gameObject.transform.position.x > 5.2)
        {
            gameController.Score1();
        }



        this.transform.position += new Vector3(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);

    }
}
