using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleDrawAndDetect : MonoBehaviour
{
    public Rect rectangle = new Rect(100, 100, 200, 200);

    public void OnGUI()
    {
        GUI.Box(rectangle, "»ç°¢Çü");

        if(Event.current.type == EventType.MouseDown)
        {
            rectangle.Contains(Event.current.mousePosition);
            {
                Debug.Log("Click!!");
            }
        }
    }
}
