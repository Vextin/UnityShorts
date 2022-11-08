using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Needed for TextMeshPro text editing.
using TMPro;


public class AddButtonToMenu : MonoBehaviour
{
    //SerializeField shows values in the inspector without making them public.
    [SerializeField] GameObject prefab;
    
    //Public void because we need other buttons to be able to call this function.
    public void AddButton(string buttonText="Button")
    {
        //Spawn a new button and save it as "go"
        GameObject go = Instantiate(prefab);
        
        //Set the button text to whatever value is set in the inspector  
        go.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;

        //Set the parent to this object. This shouldn't be done in Instantiate() for UI objects, best to do it seperately. 
        go.transform.SetParent( this.gameObject.transform, true);
            
    }
}
