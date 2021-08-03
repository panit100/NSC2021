using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Cute : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    public float moveSpeed = 4f;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    public WeaponManager currentWeapon;

    Animator animator;

    Vector3 forward,right;
    // Start is called before the first frame update
    void Start()
    {
        SetAngleMove();

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        currentWeapon = GetComponentInChildren<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LookAtMouse();
        Dash();
    }

    void SetAngleMove(){
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
    }

    void Move(){
        groundedPlayer = characterController.isGrounded;
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = (Input.GetAxis("Horizontal") * right) + (Input.GetAxis("Vertical") * forward);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            characterController.Move(move * Time.deltaTime * moveSpeed);
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
    void Dash(){
        if(Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("isDash",true);

        }
    }

    void EndDash(){
        animator.SetBool("isDash",false);

        //bool = false
    }

    void LookAtMouse(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,transform.position.y,Camera.main.transform.position.y));
        transform.LookAt(mousePos + Vector3.forward);
    }
}
