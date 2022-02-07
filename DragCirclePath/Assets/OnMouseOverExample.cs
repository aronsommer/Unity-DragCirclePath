//Attach this script to a GameObject to have it output messages when your mouse hovers over it.
using UnityEngine;

public class OnMouseOverExample : MonoBehaviour
{
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        if (Input.GetMouseButtonDown(0))
        {
            LookAtMouse.lookAtMouse = true;
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        //PointAtMouse.lookAtMouse = false;
    }

    private void Update()
    {
        if (LookAtMouse.lookAtMouse && LookAtMouse.HasStarted)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }
}