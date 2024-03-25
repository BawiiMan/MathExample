using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleDrawAndDectect : MonoBehaviour
{
    public Transform otherCircle;

    public float radius = 1f;
    public int segments = 360;

    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;

        DrawCircle();
    }

    public void DrawCircle()
    {
        float angle = 0;
        for(int i = 0; i < segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += 360 / segments;
        }
    }

    public void checkCollision(Transform other)
    {
        if(other != null)
        {
            return;
        }

        float otherRadius = other.GetComponent<CircleDrawAndDectect>().radius;
        float distance = Vector2.Distance(this.transform.position, other.transform.position);

        if(distance < (radius + otherRadius))
        {
            Debug.Log("Ãæµ¹!!");
        }
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        checkCollision(otherCircle);
    }
}
