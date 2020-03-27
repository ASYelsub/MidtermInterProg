using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This exists to enact the behavior, "double click on the mouth for it to take over the entire face through lerp
public class MouthExpand : MonoBehaviour
{
    public static int clickedCount;
    SpriteRenderer thisSR;
    Transform thisTransform;
    //Vector3 ultimateRatio;
    Vector3 initialScale, initialRotation, initialPosition;
    Vector3 newScale, newRotation, newPosition;
    Vector3 thisScale, thisRotation, thisPosition;
    float timer = 0f;
    private float resetTimer = 0f;

    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();
        thisTransform = GetComponent<Transform>();
        thisScale = thisTransform.localScale;
        thisPosition = thisTransform.localPosition;
        thisRotation = thisTransform.localEulerAngles;
        
        initialScale = new Vector3(.5f,.5f,1f);
        initialPosition = new Vector3(.53f,-3.55f,1);
        initialRotation = new Vector3(0,0,0);
        
        //ultimateRatio = new Vector3(3f, 3f, 3f);
        clickedCount = 0;
    }

    void Update()
    {
        
        //print(initialScale);
        //print(timer);
        if (MouthDrag.isBigger == false)
        {
            if (clickedCount == 0)
            {
                thisTransform.localScale = initialScale;
                thisTransform.localPosition = initialPosition;
                thisTransform.localEulerAngles = initialRotation;
            }
            else if (clickedCount == 1)
            {
                timer += 1 * Time.deltaTime;
                thisTransform.localScale = newScale;
                thisTransform.localEulerAngles = initialRotation;
                thisTransform.localPosition = newPosition;
            }

            if (clickedCount == 2)
            {
                thisTransform.localScale = newScale;
                thisTransform.localEulerAngles = newRotation;
                thisTransform.localPosition = newPosition;
                resetTimer += 1 * Time.deltaTime;
            }

            if (timer > 2f)
            {
                Unclicked(0);
            }

            if (resetTimer > 2f)
            {
                Unclicked(0);
            }
        }

    }
    private void OnMouseUp()
    {
        print("goes into func");
        if (MouthDrag.isBigger == false)
        {
            if (clickedCount == 0)
            {
                print("first time");
                ClickedOnce(0);
                //thisSR.color = Color.yellow;
                newScale = Vector3.Lerp(thisScale, new Vector3(0.90625f,1.46875f,1f), 1);
                newPosition = Vector3.Lerp(thisPosition, new Vector3(0.90625f, -3.04f, -3), 1);

            }
            else if(clickedCount == 1)
            {
                print("second time");
                ClickedOnce(1);
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
        clickedCount = cc + 1;
        Debug.Log(clickedCount);
    }
    void Unclicked(int cc)
    {
        print("unclicked");
        clickedCount = cc;
       
            thisScale = initialScale;
            thisPosition = initialPosition;
            thisPosition = initialRotation;
            thisSR.color = Color.white;
        
        print(thisScale);
        print(initialScale + "initialscale");
        print(thisScale);
        timer = 0;
        resetTimer = 0;
    }
}
