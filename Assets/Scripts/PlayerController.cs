using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float playerSpeed;

    private float horizontalInput;

    private float verticalInput;

    private float horizontalScreeninit = 9.5f;

    private float verticalScreeninit = 5.5f;

    public GameObject bulletPrefab;

    public int lives;

    public GameObject explosionPrefab;

    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = 3;
        playerSpeed = 6f;
    }

    public void LoseALife()
    {
        lives--; 
        
        if(lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.ChangeLivesText(lives);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        if(transform.position.x > horizontalScreeninit || transform.position.x < -horizontalScreeninit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if(transform.position.y > verticalScreeninit || transform.position.y < -verticalScreeninit)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, 0);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spawn bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
        }
    }
}