using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureMove : MonoBehaviour
{
    public GameObject target;
    Vector2 targetPos;
    Vector2 myTargetPos;
    float lerpNumber;
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
        lerpNumber = Random.Range(0f, .5f);
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        myTargetPos = Vector3.Lerp(transform.position, targetPos, lerpNumber);
    }


}
