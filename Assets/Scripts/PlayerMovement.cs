using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public ParticleSystem particleSystem;
    public Slider HealthBar;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Level01Controller.isPaused) {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // If left shift is pressed down the player moves faster (sprints)
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 18f;
            }
            else
            {
                speed = 12f;
            }

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                particleSystem.Emit(1);
            }
        }
    }
    public void healthBar() 
    {
        HealthBar.value = HealthBar.value - 1;
        if (HealthBar.value <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
