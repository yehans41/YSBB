using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Vector3 destination;
    public float horizontal;
    public float vertical;
    public float whereWeGoing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform just holds info about obj
        //calling translate actually moves the obj
        //transform and translate go hand to hand


        //---------------------------------------------------------
        // getAxisRaw - values are consatly being parsed
        // getAxis - values only parsed when key is pressed down
        //---------------------------------------------------------
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Debug.Log(vertical);
        switch(vertical){
            case -1: whereWeGoing=1; break;
            case 1: whereWeGoing=2; break;
        }
        switch(horizontal){
            case -1: whereWeGoing=3; break;
            case 1: whereWeGoing=4; break;
        }
        // if(vertical == -1){
        //     //down
        //     upOrDown = -1;
        // } 
        // if(vertical == 1){
        //     //up
        //     upOrDown = 1;
        // }
        //creates a random arrow illustrating where the obj is going to 
        // move, based on the inputs of the horizontal keys(a,d or left/right arrow)
        // and based on verticle keys(w,s and up/down arrow)
        // y left as 0 because that would demostrate jumping/falling

        // --- PY Notes ---
        //codey always wants to be moving forward. only need x-s for him to turn.
       switch(whereWeGoing){
        case 1: destination = new Vector3(0,0,-1);break;
        case 2: destination = new Vector3(0,0,1);break;
        case 3: destination = new Vector3(-1,0,0);break;
        case 4: destination = new Vector3(1,0,0);break;
       }
        
       
        //Debug.Log(destination);


        // ------------------------------------------------------------------
        // will move obj, based on destination ( vector made based on 
        // player inputs) then multiples by the speed we want the obj to
        // to move at. Then Time.deltaTime so it moves smoothly
        // ------------------------------------------------------------------
        //                                              V multiplied by timeDelta so action is done smoothly among multiple frames.
        transform.Translate(destination * speed * Time.deltaTime);
    }
}