using UnityEngine;
using System.Collections;

public class Player_movement : MonoBehaviour
{

    public float speed = 100;             //Floating point variable to store the player's movement speed.
    public float Stamina = 10.0f;
    public float MaxStamina = 10.0f;
    private float StaminaRegenTimer = 0.0f;
    private const float StaminaDecreasePerFrame = 7.0f;
    private const float StaminaIncreasePerFrame = 10.0f;
    private const float StaminaTimeToRegen = 1.0f;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning)
        {
            speed = 230;
            Stamina = Mathf.Clamp(Stamina - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            StaminaRegenTimer = 0.0f;
        }
        else if (Stamina < MaxStamina)
        {
            speed = 100;
            if (StaminaRegenTimer >= StaminaTimeToRegen)
                Stamina = Mathf.Clamp(Stamina + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            else
                StaminaRegenTimer += Time.deltaTime;
        }
    }
}