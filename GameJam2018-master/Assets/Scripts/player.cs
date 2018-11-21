using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    Rigidbody rb;
    public float xForce;
    //public float maxVeloc;
    public float thrust;
    private bool isGrounded;
    public GameManager gameManager;
    public GameObject completeLevelUI;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        gameManager = FindObjectOfType<GameManager>();
        completeLevelUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        //float yVeloc = rb.velocity.y;
        bool isJump = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        Vector3 jump = new Vector3(0, 100, 0);

        if (x > 0)
        {
            //rb.velocity = new Vector3(maxVeloc, yVeloc, 0);
            rb.AddForce(new Vector3(xForce, 0, 0));
        }
        else if (x < 0) rb.AddForce(new Vector3(-xForce, 0, 0)); //rb.velocity = new Vector3(-maxVeloc, yVeloc, 0);

        if (isJump && isGrounded)
        {
            rb.AddForce(jump * thrust);
            isGrounded = false;
        }

        if (rb.position.y < -15f)
        {
            gameManager.gameLost();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;

        if (collision.gameObject.CompareTag("Spike")) gameManager.gameLost();

        if (collision.gameObject.CompareTag("Breakable")) {
            collision.gameObject.AddComponent<Rigidbody>();
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelWin"))
        {
            gameManager.levelWin();
        }

        if (other.CompareTag("GameWin"))
        {
            gameManager.gameWin();
        }


    }

}
