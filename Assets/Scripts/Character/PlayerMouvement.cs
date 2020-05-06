using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject concrete;
    public GameObject duct;
    public GameObject tiles;
    public float nombreDePas = 1.0f;

    // public KeyCode sprint = KeyCode.LeftShift;

    Vector3 velocity;
    bool isGrounded;

    float deltaX = 0.0f;
    float deltaZ = 0.0f;

    // float vMulti;

    void Start()
    {
        deltaX = transform.position.x;
        deltaZ = transform.position.z;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed /* * vMulti */ * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (transform.position.x - deltaX >= nombreDePas || transform.position.x - deltaX <= -nombreDePas || transform.position.z - deltaZ >= nombreDePas || transform.position.z - deltaZ <= -nombreDePas)
        {
            deltaX = transform.position.x;
            deltaZ = transform.position.z;

            var range = Physics.OverlapSphere(groundCheck.position, groundDistance);

            foreach (Collider groundType in range)
            {
                switch (groundType.tag)
                {
                    case "Concrete":
                        concrete.transform.GetChild(Random.Range(0, 4)).GetComponent<AudioSource>().Play();
                        break;
                    case "Duct":
                        duct.transform.GetChild(Random.Range(0, 4)).GetComponent<AudioSource>().Play();
                        break;
                    case "Tiles":
                        tiles.transform.GetChild(Random.Range(0, 4)).GetComponent<AudioSource>().Play();
                        break;
                }
            }
        }

        if (x < 0)
        {
            animator.SetBool("q", true);
        }
        else
        {
            animator.SetBool("q", false);
        }
        if (x > 0)
        {
            animator.SetBool("d", true);
        }
        else
        {
            animator.SetBool("d", false);
        }
        if (z < 0)
        {
            animator.SetBool("s", true);
        }
        else
        {
            animator.SetBool("s", false);
        }
        if (z > 0)
        {
            animator.SetBool("z", true);
        }
        else
        {
            animator.SetBool("z", false);
        }
    }
}