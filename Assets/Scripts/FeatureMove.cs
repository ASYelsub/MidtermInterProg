using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script affects how the two eyes lerp to the position of the mouse when the player clicks somewhere.
public class FeatureMove : MonoBehaviour
{
    //Declaration of variables and components that will be used.
    public GameObject target; //The target is the invisble object that's position changes instantaneously when click happens.
    Vector2 targetPos;
    Vector2 myTargetPos;
    float lerpNumber = 1;
    void Start()
    {
        myTargetPos = this.transform.position;
    }

    void Update()
    {
        target.transform.position = targetPos;
//        Debug.Log(targetPos);
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
        transform.position = Vector3.Lerp(transform.position, myTargetPos, lerpNumber);
    }

    private void OnMouseDown()
    {
        if (MouthDrag.overMouth == false)
        {
            lerpNumber = Random.Range(0f, .5f);
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            myTargetPos = Vector3.Lerp(transform.position, targetPos, lerpNumber);
        }
    }


}
