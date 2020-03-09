using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthDrag : MonoBehaviour
{
    SpriteRenderer thisSR;
    protected float velocity;
    // Start is called before the first frame update
    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnMouseDrag()
    {
        float velocity = Input.GetAxis("Mouse Y");
        Debug.Log(velocity);
        if (velocity > Mathf.Abs(2f))
        {
            thisSR.color = Color.yellow;
        }
        if(velocity > Mathf.Abs(3f))
        {
            thisSR.color = Color.red;
        }
    }
}
