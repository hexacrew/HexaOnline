using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;
    public Vector2 standardMouseVector;

    public Texture2D pointer;
    public Texture2D target;
    public Texture2D doorway;
    public Texture2D combat;

    public EventVector3 OnClickEnvironment;
    
    void Start()
    {
        standardMouseVector = new Vector2(16, 16);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, standardMouseVector, CursorMode.Auto);
                door = true;
            }
            else
            {
                Cursor.SetCursor(target, standardMouseVector, CursorMode.Auto);
            }
            if (Input.GetMouseButton(0))
            {
                OnClickEnvironment.Invoke(hit.point);
            }
        } 
        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }