using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpinWithTouch : MonoBehaviour
{

	void Start()
	{
		
	}

    public void OnMouseDrag()
    {
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }
            else
            {
                
                    var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                    var hitInfo = new RaycastHit();
                    float rotSpeed = 20;
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        if (hitInfo.transform.name != transform.name)
                            return;
                        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                        transform.Rotate(Vector3.up, -rotX);

                        //var yAxis = hitInfo.point.y*rotSpeed;
                        //transform.Rotate(Vector3.up, yAxis);
                    }
                
            }
        }
        Debug.Log("Touched");
    }
}