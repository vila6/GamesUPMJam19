using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float onAirMovementFactor = 0.75f;

    private CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    private Animator myAnimator;
    private SpriteRenderer myRenderer;
    private bool onFailure = false; // Condicion de parada de movimiento por ser mongolo y no saber respirar

    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        myRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!onFailure)
        {
            //Comprueba que el controller está en el suelo
            if (controller.isGrounded)
            {
                //Asigna movimiento al vector y multiplica por una velocidad
                moveDirection = MovePlayer();
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;            
            }
            else
            {
                moveDirection = MovePlayerOnAir();
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }

            //Salto del personaje
            if (controller.isGrounded && Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                myAnimator.SetTrigger("Jump");
            }
            else
            {
                moveDirection.y = controller.velocity.y;
            }   
        }        

        //Aplica gravedad al controller
        moveDirection.y -= gravity * Time.deltaTime;

        //Mueve al personaje
        controller.Move(moveDirection * Time.deltaTime);

        // Parametros animador
        myAnimator.SetBool("isGrounded", controller.isGrounded);
        myAnimator.SetFloat("movementX", controller.velocity.x);
        myAnimator.SetFloat("movementY", controller.velocity.y);
        if(controller.velocity.x > 0.1f)
        {
            myRenderer.flipX = false;
        }
        else if(controller.velocity.x < -0.1f)
        {
            myRenderer.flipX = true;
        }
    }

    private Vector3 MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveHorizontal, 0, 0);

        return move;
    }

    private Vector3 MovePlayerOnAir()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveHorizontal * onAirMovementFactor, 0, 0);

        return move;
    }

    public void StartFailureState()
    {   
        onFailure = true;
        moveDirection = Vector3.zero;
        myAnimator.SetBool("isDrowning", true);
    }

    public void EndFailureState()
    {
        onFailure = false;
        myAnimator.SetBool("isDrowning", false);
    }

}
