using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    private CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        //Comprueba que el controller está en el suelo
        if (controller.isGrounded)
        {
            //Asigna movimiento al vector y multiploca por una velocidad
            moveDirection = MovePlayer();
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            //Salto del personaje
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        //Aplica gravedad al controller
        moveDirection.y -= gravity * Time.deltaTime;

        //Mueve al personaje
        controller.Move(moveDirection * Time.deltaTime);

        
    }

    private Vector3 MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0, 0);

        return move;
    }

}
