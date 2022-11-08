using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongRotate : MonoBehaviour
{
    [SerializeField][Tooltip(tooltip:"Object will pingpong between -range and range")] float range;
    [SerializeField] float speed;
    private float realSpeed;
    
    //OnValidate() lets us update the value during playmode and see the changes reflected immediately.
    void OnValidate ()
    {
        Setup();
    }
    void OnStart()
    {
        Setup();
    }
    
    //Setup should happen both when the script starts, and whenever values are changed in the inspector. 
    void Setup ()
    {
        realSpeed = range * 2 * speed;
    }
   
    void Update()
    {
        //Mathf.PingPong handles bouncing back and forth. Time is stretched by our speed. Range is doubled to give a (-range, +range) total range.
        float rotation = Mathf.PingPong(Time.time * realSpeed, range * 2);
        //subtract off half of the total range to center the motion
        rotation -= range;
        //X and Y stay the same, Z is set to our calculated rotation.
        transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotation);
    }
}
