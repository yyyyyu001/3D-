using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private CharacterController charcontroller;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;

    private Vector3 movement;

    public float runSpeed;
    private float currentMoveSpeed;
    public float jumpForce;
    public float gravitymod;

    public Transform groundcheck;
    public LayerMask groundlayer;
    private bool isonground;

    public Transform playerviewPoint;
    public float mouseSensitivety;
    private float verticalRotation;
    private Vector2 mouseinput;
    private Camera Playercamera;

    // Start is called before the first frame update
    void Start()
    {
        charcontroller = GetComponent<CharacterController>();
        Playercamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;//当游戏开始时鼠标光标被锁定
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.instance.isPaused)
        {


            mouseinput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivety;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseinput.x, transform.rotation.eulerAngles.z);
            verticalRotation += mouseinput.y;
            verticalRotation = Mathf.Clamp(verticalRotation, -20f, 20f);



            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            moveDirection = new Vector3(horizontalInput * moveSpeed, 0f, verticalInput * moveSpeed);

            if (charcontroller.isGrounded)
            {
                movement.y = 0f;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentMoveSpeed = runSpeed;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }

            float veticalVelocity = movement.y;
            movement = ((transform.forward * moveDirection.z) + (transform.right * moveDirection.x)).normalized * currentMoveSpeed;
            movement.y = veticalVelocity;

            if (charcontroller.isGrounded)
            {
                movement.y = 0f;
            }
            //Raycast会从地面检测点发射一些射线，从这个点射向地面图层，通过这些射线它会检查我们是否在地面上

            isonground = Physics.Raycast(groundcheck.position, Vector3.down, 0.25f, groundlayer);
            if (Input.GetButtonDown("Jump") && isonground)
            {
                movement.y = jumpForce;
                AudioManager.instance.PlaySfx(2);
            }

            movement.y += (Physics.gravity.y * gravitymod * Time.deltaTime);//movement.y = movement.y+(Physics.gravity.y * gravitymod * Time.deltaTime)


            charcontroller.Move(movement * Time.deltaTime);//Time.deltaTime帧之间的时间，能帮助我们标准化移动

            if (Input.GetKeyDown(KeyCode.Escape))//如果我们按下esc键就会解锁光标
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }


    private void LateUpdate()
    {
        Playercamera.transform.position = playerviewPoint.position;
        Playercamera.transform.rotation = playerviewPoint.rotation * Quaternion.Euler(verticalRotation, 0f, 0f);

    }
}
