using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{

    public GameObject Player;
    public GameObject Target;
    public PlayerInput Input;
    private float MouseX = 0f;
    private float MouseY = 0f;
    public float LookSensitive = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookVector = this.Input.actions["Look"].ReadValue<Vector2>();
        this.MouseX += lookVector.x * LookSensitive;
        this.MouseY -= lookVector.y * LookSensitive;
        this.MouseY = Mathf.Clamp(MouseY, -30f, 60f);
        this.Target.transform.rotation = Quaternion.Euler(MouseY, MouseX, 0);
        this.Player.transform.rotation = Quaternion.Euler(0, MouseX, 0);
    }
}
