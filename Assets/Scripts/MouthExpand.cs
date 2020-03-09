using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This exists to enact the behavior, "double click on the mouth for it to take over the entire face through lerp
public class MouthExpand : MonoBehaviour
{
    private int clickedCount;
    SpriteRenderer thisSR;
    Transform thisTransform;
    Vector3 ultimateRatio;
    Vector3 newScale;
    Vector3 thisScale;
    float timer = 0f;

    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();
        thisTransform = GetComponent<Transform>();
        thisScale = thisTransform.localScale;
        ultimateRatio = new Vector3(3f, 3f, 3f);
        clickedCount = 0;
    }

    void Update()
    {
        if (clickedCount == 1)
        {
            timer += 1 * Time.deltaTime;
        }
        if(timer > 6f)
        {
            Unclicked(0);
        }
        if(clickedCount == 2)
        {
            thisScale = newScale;
        }
        thisTransform.localScale = thisScale;
    }
    private void OnMouseUp()
    {
        print("goes into func");
        if (clickedCount == 0)
        {
            print("first time");
            ClickedOnce(0);
            thisSR.color = Color.yellow;
        }
        else if(clickedCount == 1)
        {
            print("second time");
            ClickedOnce(1);
            newScale = Vector3.Lerp(thisScale,new Vector3(thisScale.x * ultimateRatio.y,
                                                          thisScale.x * ultimateRatio.y),2);
        }
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
        thisSR.color = Color.white;
        timer = 0;
    }
}
