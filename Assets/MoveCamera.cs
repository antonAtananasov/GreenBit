using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCamera : MonoBehaviour
{
    //public float speed = 1;
    public float scrollFraction = .03f;
    public Vector3 cameraBoundaryMin, cameraBoundaryMax;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame

    Vector3 oldMousePos;
    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            transform.Translate(0, 0, transform.position.y * scroll * scrollFraction);
        }
        if (true)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {
                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                transform.Translate(0, 0, transform.position.y * -deltaDistance * scrollFraction/100*3);
            }
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            oldMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {

            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseDelta = oldMousePos - mousePosition;

            if (Input.GetMouseButton(0))
            {
                mouseDelta.z = mouseDelta.y;
                mouseDelta.y = 0;
                Vector3 offset = Vector3.forward * transform.position.y;
                transform.Translate(-Camera.main.ScreenToWorldPoint(mousePosition + offset) + Camera.main.ScreenToWorldPoint(oldMousePos + offset), Space.World);
            }
            oldMousePos = mousePosition;
        }
        print(transform.position);
        print(cameraBoundaryMin);
        print(cameraBoundaryMax);
        Vector3 clampedPos = Vector3.one;
        clampedPos.x = Mathf.Clamp(transform.position.x, cameraBoundaryMin.x, cameraBoundaryMax.x);
        clampedPos.y = Mathf.Clamp(transform.position.y, cameraBoundaryMin.y, cameraBoundaryMax.y);
        clampedPos.z = Mathf.Clamp(transform.position.z, cameraBoundaryMin.z, cameraBoundaryMax.z);
        transform.position = clampedPos;
    }

    [ContextMenu("Reset Position")]
    public void ResetPos()
    {
        transform.position = startPos;
    }

}