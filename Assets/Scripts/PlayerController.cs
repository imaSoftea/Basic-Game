using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }



    private float yStore;

    public CharacterController charCon;

    private CameraController cam;

    private Vector3 moveAmount;
    public float moveSpeed = 5f;
    public float rotateSpeed = 10f;

    public Animator anim;

    void Start()
    {
        cam = FindObjectOfType<CameraController>();

        anim = gameObject.GetComponent<Animator>();
    }

    void Update(){

        yStore = moveAmount.y;

        moveAmount = (cam.transform.forward * Input.GetAxisRaw("Vertical")) + (cam.transform.right * Input.GetAxisRaw("Horizontal"));
        moveAmount.y = 0f;
        moveAmount = moveAmount.normalized;

        if (moveAmount.magnitude > .1f)
        {
            if (moveAmount != Vector3.zero)
            {
                Quaternion newRot = Quaternion.LookRotation(moveAmount);

                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, rotateSpeed * Time.deltaTime);
            }
        }

        charCon.Move(new Vector3(moveAmount.x * moveSpeed, moveAmount.y, moveAmount.z * moveSpeed) * Time.deltaTime);

        float moveVel = new Vector3(moveAmount.x, 0f, moveAmount.z).magnitude * moveSpeed;

        bool isArrowKeyPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
                                 Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        anim.SetBool("isWalking", isArrowKeyPressed);
        Debug.Log(isArrowKeyPressed);
    }

}
