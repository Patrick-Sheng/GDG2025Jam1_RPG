// using System.Collections;
// using UnityEngine;
// using UnityEngine.InputSystem;


// public class PlayerController2 : MonoBehaviour
// {

//    private bool playerdeadonthefloor;

//    public static bool dodio;

//    public Animator anim;

//    public float moveSpeed;

//    private float x, y;
//    private Vector2 input;

//    Rigidbody2D rb;

//    private bool moving;

    
     
//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();

        
//    }
//    private void Update()
//    {

//        if (StaticManager.PlayerDead == true && playerdeadonthefloor == false)
//        {
//            anim.Play("dead");
//            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 2f, gameObject.transform.position.y - 0.8f);
//            playerdeadonthefloor = true;
//        }



//        if (!DialogueManager.GetInstance().dialogueIsPlaying)
//        {
//            GetInput();
//            Animate();
//        }
//        else
//        {
//            rb.linearVelocity = Vector2.zero;
//            anim.SetBool("Moving", false);
//        }
            


//    }
//    private void FixedUpdate()
//    {
//        if (DialogueManager.GetInstance().dialogueIsPlaying)
//        {
//            return;
//        }
//        rb.linearVelocity = input * moveSpeed;
//    }

//     // public void Move(InputAction.CallbackContext context) 
//     // {
//     //     if (!DialogueManager.GetInstance().dialogueIsPlaying && !StaticManager.LayingDownRightnow)
//     //     {
//     //         input = context.ReadValue<Vector2>() * moveSpeed;
//     //     }
//     // }
//    public void Move(InputAction.CallbackContext context) 
//    {
//        if (!StaticManager.carHit)
//        {
//            if (!DialogueManager.GetInstance().dialogueIsPlaying)
//            {
//                input = context.ReadValue<Vector2>() * moveSpeed;
//            }
//            else
//            {
//                input = Vector2.zero;
//            }
//        }
//        else
//        {
//            input = Vector2.zero;
//        }

//    }
//    private void GetInput()
//    {
//        //OLD MOVEMENT SYSTEM

//        //x = Input.GetAxisRaw("Horizontal") * moveSpeed;
//        //y = Input.GetAxisRaw("Vertical") * moveSpeed;
//        //input = new Vector2(x, y);



//        //you can add .normalise or whatever to the end of this Vector and it all diagonal will b the same
//    }

//    private void Animate()
//    {
//        if (StaticManager.PlayerDead == false)
//        {
//            if (input.magnitude > 0.1f || input.magnitude < -0.1f)
//            {
//                moving = true;
//            }
//            else
//            {
//                moving = false;
//            }

//            if (moving)
//            {
//                if (input.x != 0)
//                {
//                    anim.SetFloat("X", input.x);
//                    anim.SetFloat("Y", 0f);
//                }
//                else
//                {
//                    anim.SetFloat("X", 0f);
//                    anim.SetFloat("Y", input.y);
//                }

//                //old Version
//                //anim.SetFloat("X", x);
//                //anim.SetFloat("Y", y); 

//            }

//            anim.SetBool("Moving", moving);
//        }



//    }



// }
