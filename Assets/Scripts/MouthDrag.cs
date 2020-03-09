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
    SpriteRenderer thisSR;
    private float velocity;
    private bool isClicked;
    public static bool overMouth; //This script also disables other scripts from running
                                        //when the player is using the mouth.
    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();
    }
    private void OnMouseEnter()
    {
        isClicked = true;
        overMouth = true;
    }
    private void OnMouseDrag()
    {
        float velocity = Input.GetAxis("Mouse Y");
        //Debug.Log(velocity);
        if (isClicked) //this bool here makes it so that the color doesn't flicker between red and yellow,
                                //in order to emphasize the feeling of Pulling the player will experience.
        {
            if (velocity > Mathf.Abs(redThresh))
            {
                thisSR.color = Color.red;
                
            }
            else if (velocity > Mathf.Abs(yellowThresh))
            {
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
