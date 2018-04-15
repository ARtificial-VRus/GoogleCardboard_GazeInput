using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class Maric_TimeGazeClick : MonoBehaviour {
    //get the button
    public GameObject button; 
    //the time how long the user must look on an object to trigger a click
    public float gazeTime = 2f;
    //Boolean to indicate if we gaze on the button
    private bool gazedAt = false;
	//We need a timer in order to measure the time
	//Float allows decimals.
	private float timer;

    //cube manipulation
    public GameObject cube;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //once every frame we want to increment the timer
        if(gazedAt)
        {
            //we start the timer and adjust it to the frame rate with delta time
            timer += Time.deltaTime;
            // if timer is greater than the gazeTime we want to trigger the click remotely
            if (timer > gazeTime)
            {
                // to trigger the event remotely we must import UnityEngine.EventSystems class 
                // in order to utilize the ExecuteEvents-Method.
                ExecuteEvents.Execute(button, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                //reset timer to prevent continous cklicking
                timer = 0f;

            }

        }
		
	}
	
	//We want to control what happens if the GazePointer enters, exit and click on a button
	public void OnPointerEnter()
	{
        //set the bool to true
        gazedAt = true;
		Debug.Log("Pointer Enter");
	}
	
	public void OnPointerExit()
	{
        //set the bool to false.
        gazedAt = false;
		Debug.Log("Pointer Exit");
	}
	
	public void OnPointerClick()
	{
        cube.transform.Rotate(new Vector3(0f, 45f, 0f));
        Debug.Log("Pointer click");

	}

}
