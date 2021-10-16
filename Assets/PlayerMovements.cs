using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    public float JumpStrength = 15f;
    public float ForwardSpeed = 5f;
    public float GravityAcc = -0.98f;
    public Vector3 Velocity;
    private CharacterController Controller;
    private PlayerInput Input;
    private float JmpCounter = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        this.Controller = GetComponent<CharacterController>();
        this.Input = GetComponent<PlayerInput>();
        Input.actions["Jump"].performed += this.Jump;
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        Movement();
        ChangeState();
    }

    void ChangeState()
    {
        //Допустим будет работать
        Controller.Move(Velocity * Time.deltaTime);
    }

    void Movement()
    {
        Vector2 Move1 = Input.actions["Move"].ReadValue<Vector2>();
        Vector3 Move2 = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f) * new Vector3(Move1.x, 0f, Move1.y);
        Velocity.x = Move2.x * ForwardSpeed; 
        Velocity.z = Move2.z * ForwardSpeed ;
    }

    void Gravity ()
    {
        if(!Controller.isGrounded)
        {
            Velocity.y += GravityAcc;
        }
    }

    void Jump(InputAction.CallbackContext context)
    {
        if (Controller.isGrounded && Random.Range(-100f, 100f) > 20 )
        {
            Velocity.y = JumpStrength + JmpCounter;
            JmpCounter = Random.Range(-9.8f, 30f);
        }
        
    }
}
