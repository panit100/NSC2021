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
    Vector3 move;


    [Header("Dash variable")]
    public float dashSpeed;
    public float dashTime;
    public float delayDash;
    public float currentTime = 0;
    bool isDash = false;


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
        currentTime += Time.deltaTime;

        Move();
        LookAtMouse();
        //DashbyAnimation();

        if(Input.GetKeyDown(KeyCode.Space) && currentTime >= delayDash){
            StartCoroutine(Dash());
        }
    }
    

    //Set angle player will move
    void SetAngleMove(){
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
    }


    //Player movement
    void Move(){
        groundedPlayer = characterController.isGrounded;
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        move = (Input.GetAxis("Horizontal") * right) + (Input.GetAxis("Vertical") * forward);

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
    


    //Player look follow mouse cursor
    void LookAtMouse(){
        Vector3 playerLook;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            playerLook = ray.GetPoint(hit.distance);
            playerLook.y = transform.position.y;
            
            Debug.DrawLine(ray.origin,playerLook,Color.red);
            

            transform.LookAt(playerLook);
        }

        
    }

    //Dash by script
    IEnumerator Dash(){
        print("Dash");
        float startTime = Time.time;

        while(Time.time < startTime + dashTime){
            characterController.Move(move * dashSpeed * Time.deltaTime);
            currentTime = 0;
            yield return null;
        }
    }

    //Dash by animation
    void DashbyAnimation(){
        if(Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("isDash",true);

        }
    }

    void EndDashbyAnimation(){
        animator.SetBool("isDash",false);

        //bool = false
    }
}
