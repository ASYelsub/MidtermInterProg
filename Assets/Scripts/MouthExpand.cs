using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This exists to enact the behavior, "double click on the mouth for it to take over the entire face
public class MouthExpand : MonoBehaviour
{
    public static int clickedCount; //it's public static so there is only one instance and its easily accessible by 
                                            //MouthDrag so that if the mouth is big, the mouth corners cannot change.
    SpriteRenderer thisSR; //sprite renderer of the mouth,  it is referenced because of earlier playtesting w color
    Transform thisTransform; //this is important is it is the only way the mouth changes in this script
    //Vector3 ultimateRatio;

    //although these vectors could be in a multi-dimensional array, i actually found they confuse me less when
    //formatted like this, especially when calling them.
    Vector3 initialScale, initialRotation, initialPosition; //saves the initial transform of the mouth
    Vector3 newScale, newRotation, newPosition; //the transform it will lerp to when clickedCount increases
    Vector3 thisScale, thisRotation, thisPosition; //the Vector3 that the transform is set to in update,
                                                        //communicates w new and initial vectors.
    float timer = 0f; //timer that starts on first click, mouth goes back to normal if not clicked in time
    private float resetTimer = 0f; //timer that starts on second click
    //honestly, these two could be the same thing.

    void Start()
    {
        //thisSR = GetComponent<SpriteRenderer>(); //for earlier playtesting
        thisTransform = GetComponent<Transform>();
        thisScale = thisTransform.localScale;
        thisPosition = thisTransform.localPosition;
        thisRotation = thisTransform.localEulerAngles;
        
        //these are set here because it was not setting back to what it was originally,
        //it was being weird.
        initialScale = new Vector3(.5f,.5f,1f);
        initialPosition = new Vector3(.53f,-3.55f,1);
        initialRotation = new Vector3(0,0,0);
        
        //ultimateRatio = new Vector3(3f, 3f, 3f);
        clickedCount = 0; //the important number, lets all the functions and if statements know what they should be
                                //doing in the moment.
    }

    void Update()
    {
        
        //print(initialScale);
        //print(timer);
        if (MouthDrag.isBigger == false) //this is so it cannot expand if the corners are pulled
        {
            //i considered using a switch statement here but the static variable doesn't bode (for me, mentally)
            //well with an enum,
                //and using a switch statement is honestly sort of confusing without them.
            if (clickedCount == 0)
            {
                //sets transform to the initialPos if nothing has been clicked
                thisTransform.localScale = initialScale;
                thisTransform.localPosition = initialPosition;
                thisTransform.localEulerAngles = initialRotation;
            }
            else if (clickedCount == 1)
            {
                //sets transform to state 2, also starts timer
                timer += 1 * Time.deltaTime;
                thisTransform.localScale = newScale;
                thisTransform.localEulerAngles = initialRotation;
                thisTransform.localPosition = newPosition;
            }

            if (clickedCount == 2)
            {    //state 3, et cetera
                thisTransform.localScale = newScale;
                thisTransform.localEulerAngles = newRotation;
                thisTransform.localPosition = newPosition;
                resetTimer += 1 * Time.deltaTime;
            }

            if (timer > 2f)
            {
                Unclicked(0); //if the timer goes past and it is not clicked again, this function is called
            }

            if (resetTimer > 2f)
            {
                Unclicked(0); //same here. honestly these two could be the same thing.
            }
        }

    }
    private void OnMouseUp()
    {
        print("goes into func");
        if (MouthDrag.isBigger == false)
        {
            if (clickedCount == 0) //if it's 0 and clicked, go to this state.
            {
                print("first time");
                ClickedOnce(0); //adds 1 to clickedCount
                //thisSR.color = Color.yellow;
                newScale = Vector3.Lerp(thisScale, new Vector3(0.90625f,1.46875f,1f), 1); //the lerp could definitely be more elegant with an increasing 3rd value, but i thought this was fine.
                newPosition = Vector3.Lerp(thisPosition, new Vector3(0.90625f, -3.04f, -3), 1);
                
            }
            else if(clickedCount == 1)
            {
                //et cetera
                print("second time");
                ClickedOnce(1); //adds to clickedCount, which is now at 2
                newScale = Vector3.Lerp(thisScale, new Vector3(-1.504269f,3.26212f,1f), 1);
                newRotation = Vector3.Lerp(thisRotation,new Vector3(0,0,-40.531f),1);
                newPosition = Vector3.Lerp(thisPosition, new Vector3(-0.01f, 0.31f, -3), 1);
            }
        }
    }
    private void OnMouseEnter() 
    {
        MouthDrag.overMouth = true; //an integration of the variable declared in MouthDrag
    }
    private void OnMouseExit()
    {
        MouthDrag.overMouth = false; //and then this as well
    }
    void ClickedOnce(int cc)
    {
        clickedCount = cc + 1; //sets clickedCount to the number inputted by the function plus 1
        Debug.Log(clickedCount);
    }
    void Unclicked(int cc)
    {
        print("unclicked");
        clickedCount = cc; //sets clickedCount to 0
       
        //reset the transform to how it originally looked
        thisScale = initialScale;
        thisPosition = initialPosition;
        thisPosition = initialRotation;
            //thisSR.color = Color.white;
        
        print(thisScale);
        print(initialScale + "initialscale");
        print(thisScale);
        timer = 0; //sets these to 0 if the player doesnt click in time
        resetTimer = 0; //set to 0 so it can return to its original state
    }
}
