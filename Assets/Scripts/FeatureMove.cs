using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script affects how the two eyes lerp to the position of the mouse when the player clicks somewhere.
public class FeatureMove : MonoBehaviour
{
    //Declaration of variables and components that will be used.
    public GameObject target; //The target is the invisble object that's position changes instantaneously when click happens.
    Vector2 targetPos; //where the position of the target is stored
    Vector2 myTargetPos; //where the changing position of the 
    float lerpNumber = 1;
    void Start()
    {
        myTargetPos = this.transform.position;
    }

    void Update()
    {
        target.transform.position = targetPos; //sets the position of the eye to targetPos every frame
//        Debug.Log(targetPos);
        if (Input.GetMouseButtonDown(0)) //checks every frame if the mouse is being clicked, the boolean overMouth could be checked here but isn't
        {
            OnMouseDown(); //a built,by me, function for what happens when you click
        }
        transform.position = Vector3.Lerp(transform.position, myTargetPos, lerpNumber); //lerps from transform.position to mytargetPos by the percentage of the current lerpNumber
                                                                                                    //sets position of the eye to that value
    }

    private void OnMouseDown()
    {
        if (MouthDrag.overMouth == false) //variable from MouthDrag so you cannot move the eyes while over the mouth
        {
            lerpNumber = Random.Range(0f, .5f); //randomly sets lerpNumber, smaller so it is not as crazy of a distance potentially 
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //sets targetPos to where the mouse was clicked, This I believe is something not learned in classes
            myTargetPos = Vector3.Lerp(transform.position, targetPos, lerpNumber); //also uses lerpNumber, sets myTargetPos on a line lerpNumber% away from transform.position towards targetPos
        }
    }


}
