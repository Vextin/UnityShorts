using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//To be attached to a sprite. Sprite will grow when clicked and gently shrink back down. 
//curve should half two frames: one at (0, 1) and one at (1, 0) (that is to say, start at 1 and end at 0)
public class ClickScaleAnim : MonoBehaviour
{
    float goalScale;
    [SerializeField] float scaleIncrease;
    //Anim curves give us an easy way to author the easing for the scale animation.
    [SerializeField] AnimationCurve curve;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        //We should always aim to return to our initial scale. Scale should be equal on all axes, so pick X arbitrarily. 
        goalScale = transform.localScale.x;
        //only really needs to be 1, but for safety, make sure the animation is SUUUUPER over when the game starts.
        time = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //our new scale is the original scale 
        //(goalScale * Vector3.one is the same as (goalScale, goalScale, goalScale))
        //PLUS the value at this point in the curve * the amount our scale should increase (again, as a vector)
        transform.localScale = goalScale * Vector3.one + curve.Evaluate(time) * scaleIncrease * Vector3.one;
    }

    void OnMouseDown ()
    {
        //Whenever we click, restart the animation and immediately set the scale to scaleIncrease.
        time = 0;
        transform.localScale += scaleIncrease * Vector3.one;
    }
}
