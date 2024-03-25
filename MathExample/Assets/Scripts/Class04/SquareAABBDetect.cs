using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SquareAABBDetect : MonoBehaviour
{
    public Transform square1;
    public Transform square2;

    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;

    public float size = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
       lineRenderer1 = square1.gameObject.AddComponent<LineRenderer>();
       lineRenderer2 = square2.gameObject.AddComponent<LineRenderer>();

        SetupSquare(lineRenderer2, square2.position, new Vector3(0.1f, 0, 0));
        SetupSquare(lineRenderer2, square2.position, new Vector3(0f, 0, 0));
    }

    public void SetupSquare(LineRenderer lineRenderer, Vector3 position, Vector3 offset)
    {
        lineRenderer.positionCount = 5;
        lineRenderer.useWorldSpace = true;
        lineRenderer.loop = true;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        float halfSize = size / 2;
        Vector3[] points = new Vector3[]
        {
            new Vector3(position.x - halfSize + offset.x, position.y + halfSize + offset.y, position.z + offset.z),
            new Vector3(position.x + halfSize + offset.x, position.y + halfSize + offset.y, position.z + offset.z),
            new Vector3(position.x + halfSize + offset.x, position.y - halfSize + offset.y, position.z + offset.z),
            new Vector3(position.x - halfSize + offset.x, position.y - halfSize + offset.y, position.z + offset.z),
            new Vector3(position.x - halfSize + offset.x, position.y + halfSize + offset.y, position.z + offset.z),
        };
        lineRenderer.SetPositions(points);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsCollision(square1, square2, size))
        {
            Debug.Log("Ãæµ¹!!");
        }
    }

    public bool IsCollision(Transform sq1, Transform sq2, float squareSize)
    {
        float halfSize = size / 2;
        bool xCollider = Mathf.Abs(sq1.position.x - square2.position.x) < squareSize;
        bool xCollider = Mathf.Abs(sq1.position.y - square2.position.y) < squareSize;

        return xCollider && yCollider;
    }
}
