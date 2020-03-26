using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script exists to manage mouth corner movement when the player is clicking on the mouth corners.
//they should be able to cick and pull, in a sort of feeling, and that is done through all the OnMouse functions.
//there is also velocity of the mouse in play, they need a certian amount of force to get the mouth to move
//in any specific way.
public class MouthDrag : MonoBehaviour
{
    [SerializeField]        //these two variables are visible in the inspector in order to change easily
    private float yellowThresh; //Although this is initially yellow, it actually corresponds to
    [SerializeField]            //the size of the mouth corner.
    private float redThresh;                     
    [SerializeField]
    private SpriteRenderer mouthCornerSR;
    private float velocity;
    private bool isClicked;
    public static bool overMouth; //This script also disables other scripts from running when the player is using the mouth.
    private SpriteRenderer thisSR;
    private Transform thisTransform;
    private Vector3 thisPosition;
    [SerializeField]
    private Sprite[] mouthParts = new Sprite[2];
    
    void Start()
    {
    }

    private void Update()
    {
        thisTransform = this.GetComponent<Transform>();
        thisPosition = thisTransform.position;
        thisSR = this.GetComponent<SpriteRenderer>();
        print(isClicked);
       // velocity = Input.GetAxis("Mouse Y");
        print(velocity);

    }

    private void OnMouseEnter()
    {
        overMouth = true;
    }

    private void OnMouseDown()
    {
        isClicked = true;

    }

    private void OnMouseDrag()
    {
        velocity = Input.GetAxis("Mouse Y");
        //Debug.Log(velocity);
        if (isClicked) //this bool here makes it so that the color doesn't flicker between red and yellow,
                                //in order to emphasize the feeling of Pulling the player will experience.
        {
            if (velocity > Mathf.Abs(redThresh))
            {
                mouthCornerSR.enabled = true;
                mouthCornerSR.sprite = mouthParts[1];
                thisSR.color = Color.red;
                print("was dragged");
                
            }
            else if (velocity > Mathf.Abs(yellowThresh))
            {
                mouthCornerSR.enabled = true;
                mouthCornerSR.sprite = mouthParts[0];
                thisSR.color = Color.yellow;
            }
            //Debug.Log("Velocity: " + velocity + " Threshold: " + redThresh);
            //Debug.Log("Velocity: " + velocity + " Threshold: " + yellowThresh);
        }

    }
    private void OnMouseExit()
    {
        isClicked = false;
        overMouth = false;
    }
}
