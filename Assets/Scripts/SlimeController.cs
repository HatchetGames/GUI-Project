using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D myRigidBody;
    private Animator anim;

    private bool moving;
    private Vector3 moveDirection;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;

    public float timeToMove;
    private float timeToMoveCounter;

    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;

	// Use this for initialization
	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    // Update is called once per frame
    void Update ()
    {
        if (moving == true)
        {
            timeToMoveCounter -= Time.deltaTime;

            myRigidBody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;

                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

                anim.SetFloat("MoveX", moveDirection.x);
                anim.SetFloat("MoveY", moveDirection.y);
                anim.SetBool("Walking", moving);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;

            myRigidBody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timeToMove
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);

                anim.SetFloat("MoveX", moveDirection.x);
                anim.SetFloat("MoveY", moveDirection.y);
                anim.SetBool("Walking", moving);
            }
        }

        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                thePlayer.SetActive(true);
            }
        }

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;
        }
    }
}
