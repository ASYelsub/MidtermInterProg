using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script exists to manage mouth corner movement when the player is clicking on the mouth corners.
//they should be able to cick and pull, in a sort of feeling, and that is done through all the OnMouse functions.
//there is also velocity of the mouse in play, they need a certain amount of force to get the mouth to move
//in any specific way.
//It is on both of the mouth corners and affects them in the same way, other than the mouthCornerSR is publicly inputted
    //so the sprites that input and change are different depending on the side.
public class MouthDrag : MonoBehaviour
{
    [SerializeField]        //these two variables are visible in the inspector in order to change easily
    private float yellowThresh; //Although for playtesting this was initially yellow, it actually corresponds to
    [SerializeField]            //the sprite showing of the mouth corner.
    private float redThresh;                     
    [SerializeField]
    private SpriteRenderer mouthCornerSR;
    private float velocity;
    private bool isClicked;
    public static bool isBigger;
    public static bool overMouth; //This script also disables other scripts from running when the player is using the mouth.
    private SpriteRenderer thisSR;
    private Transform thisTransform;
    private Vector3 newPosition;
    [SerializeField]
    private Sprite[] mouthParts = new Sprite[2];
    
    void Start()
    {
        thisSR = this.GetComponent<SpriteRenderer>(); //Initially, the SpriteRenderer for the corner of the mouth
                                                        //is turned off.
    }
    
    //Stuff was debugged via the use of Update.
    private void Update()
    { 
        // print(isClicked);
        // velocity = Input.GetAxis("Mouse Y"); 
        // print(velocity);
     
    }

    private void OnMouseEnter()
    {
        overMouth = true; //This is a variable to keep the eyes from moving if the player is
                            //interacting with the mouth.
    }

    private void OnMouseDown()
    {
        isClicked = true; //This tells the program that it may start measuring and comparing velocity of the mouse in the
                            //function, "OnMouseDrag" right below.
    }

    private void OnMouseDrag()
    {
        velocity = Input.GetAxis("Mouse Y"); //I believe this is something we didn't quite learn in class, "GetAxis"
                                                //this velocity is set according to how quick the player is moving the mouse
                                                    //on the Y axis of the computer screen.
        //Debug.Log(velocity);
        if (isClicked && MouthExpand.clickedCount <= 1) //this bool here makes it so that the color doesn't flicker between red and yellow,
                                //in order to emphasize the feeling of Pulling the player will experience.
        {
            if (velocity > redThresh) //redThresh & yellowThresh are set in the editor, they are the number which the velocity
                                            //of the mouse movement must surpass in order for the mouth to change states.
            {
                mouthCornerSR.enabled = true; //this is more of an illusion... instead of actually changing the mouth shown,
                                                //i just put a sprite over it. I did this with the help of photoshop and a
                                                    //black & white color palette.
                mouthCornerSR.sprite = mouthParts[1]; //sets it to which of the two sprites it is
                thisSR.color = Color.red; //this was older and for debugging purposes, before i had the art in.
                print("was dragged");
                isBigger = true; //this variable exists so that the mouth cannot be expanded in MouthExpand when
                                    //the player has the mouth changed here in MouthDrag.

            }
            else if (velocity > yellowThresh) //again... everything is similar here and below, just different cases.
            {
                mouthCornerSR.enabled = true;
                mouthCornerSR.sprite = mouthParts[0];
                thisSR.color = Color.yellow;
                isBigger = true;
            }
            else if (velocity < -redThresh)
            {
                mouthCornerSR.enabled = false;
                thisSR.color = Color.blue;
                isBigger = false;    //resetting to the original mouth
            }
            else if (velocity < -yellowThresh)
            {
                mouthCornerSR.enabled = true;
                mouthCornerSR.sprite = mouthParts[0];
                isBigger = true;
            }
            //Debug.Log("Velocity: " + velocity + " Threshold: " + redThresh);
            //Debug.Log("Velocity: " + velocity + " Threshold: " + yellowThresh);
        }

    }
    private void OnMouseExit() //the process of the script now no longer is happening.
    {
        isClicked = false;
        overMouth = false;
    }
}
