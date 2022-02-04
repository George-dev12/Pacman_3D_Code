using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //float gravity;
    GameObject coin;
    //private float health = 3;
    private int points = 0;
    CharacterController player;
    [Header("ustawia prędkość postaci")]
    public float speedIncrease = 25.0f; // ustawiamy podstawowa predkosc, z ktora bedzie sie zwiekszac predkosc postaci
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // Przypisujemy zmiennej player element sesji posiadający komponent Rigidbody
        coin = GameObject.FindGameObjectWithTag("Coin");
        player = GetComponent<CharacterController>();
        //Debug.Log(health);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        //if (player.isGrounded) gravity -= 9.81f * Time.deltaTime; // grawitacja ziemska
        //else gravity = 0.0f;
        //transform.right -> moveX poniewaz W S dzialaja na plaszczyznie X (przod tyl)
        // transform.forward -> moveZ poniewaz A i D dzialaja na plaszczyznie Z (lewo prawo)
        Vector3 movement = (transform.right * moveX + transform.forward * moveZ);
        player.Move(movement * speedIncrease * Time.deltaTime);
        if (points == 1) 
        {
            Debug.Log("You won!");
            Destroy(this.gameObject);
            GameManager.instance.won = true;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Coin")
        {
            //Debug.Log("Zderzenie z coin");
            Destroy(hit.gameObject);
            points++;
            Debug.Log("Your points: " + points);
        }
    }
}
