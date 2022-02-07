using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    Vector3 pointingTarget;
    public static bool lookAtMouse;
    public static bool HasStarted;

    void Start()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        // To arrange the objects at start
        lookAtMouse = true;
        yield return new WaitForSeconds(0.1f);
        lookAtMouse = false;
        HasStarted = true;

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && HasStarted)
        {
            Debug.Log("Drag ended!");
            lookAtMouse = false;
        }

        if (lookAtMouse)
        {
            pointingTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.back * Camera.main.transform.position.z);
            transform.LookAt(pointingTarget, Vector3.back);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointingTarget, 0.2f);
        Gizmos.DrawLine(transform.position, pointingTarget);
    }
}