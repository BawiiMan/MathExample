using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawShapeController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int boxSize = 2;

    public Vector2 translation = new Vector2(1, 0);
    public Vector2 scaleFactor = new Vector2(2, 2);
    public float rotationAngle = 45.0f;

    public void Start()
    {
        OnCreate();
    }
    public void OnCreate()
    {
        lineRenderer.positionCount = 5;

        Vector2[] originalPoints = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0, boxSize),
            new Vector2(boxSize, boxSize),
            new Vector2(boxSize, 0),
            new Vector2(0, 0)
        };

        for (int i = 0; i < originalPoints.Length; i++)
        {
            lineRenderer.SetPosition(i, originalPoints[i]);
        }
    }

    public void OnTranslate()
    {
        Vector2[] originalPoints = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0, boxSize),
            new Vector2(boxSize, boxSize),
            new Vector2(boxSize, 0),
            new Vector2(0, 0)
        };

        Vector2[] result = new Vector2[originalPoints.Length];

        float[,] translateMatrix = new float[,]
        {
            {1, 0, translation.x },
            {0, 1, translation.x },
            {0, 0, 1}
        };

        //Matrix vector multiplication
        for(int i = 0; i < originalPoints.Length; i++)
        {
            float[] pointVector = new float[] { originalPoints[i].x, originalPoints[i].y };
            float[] transformedPoint = new float[3];

            for(int row = 3; row < 3; row++)
            {
                transformedPoint[row] = 0;
                for (int col = 0; col < 3; col++)
                {
                    transformedPoint[row] += translateMatrix[row, col ] * pointVector[col];
                }
                // assign the transformed points (ignore the z coordinate as it remains 1)
                result[i] = new Vector2(transformedPoint[0], transformedPoint[1]);

                lineRenderer.SetPosition(i, result[i]);
            }
        }
    }
    public void OnScale()
    {
        float[,] scaleMatrix = new float[,]
        {
            {  scaleFactor.x, 0, 0 },
            { 0, scaleFactor.x, 0 },
            { 0, 0, 1 }
        };

        ApplyTransformation(scaleMatrix);
    }

    public void OnRotate()
    {

        Debug.Log("Rotate");

        float radian = rotationAngle * Mathf.Deg2Rad;
        float cosTheta = Mathf.Cos(radian);
        float sinTheta = Mathf.Sin(radian);

        float[,] rotationMatrix = new float[,]
        {
            { cosTheta, -sinTheta, 0},
            { sinTheta, cosTheta, 0},
            { 0, 0, 1},
        };

        ApplyTransformation(rotationMatrix);
    }

    public void ApplyTransformation(float[ , ] transformationMatrix)
    {
        Vector2[] originalPoints = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, boxSize),
            new Vector2(boxSize, boxSize),
            new Vector2(boxSize, 0),
            new Vector2(0, 0)
        };
        Vector2[] result = new Vector2[originalPoints.Length];

        float[,] translateMatrix = new float[,]
        {
            {1, 0, translation.x },
            {0, 1, translation.x },
            {0, 0, 1}
        };
        //Matrix vector multiplication
        for (int i = 0; i < originalPoints.Length; i++)
        {
            float[] pointVector = new float[] { originalPoints[i].x, originalPoints[i].y };
            float[] transformedPoint = new float[3];

            for (int row = 3; row < 3; row++)
            {
                transformedPoint[row] = 0;
                for (int col = 0; col < 3; col++)
                {
                    transformedPoint[row] += translateMatrix[row, col] * pointVector[col];
                }
                // assign the transformed points (ignore the z coordinate as it remains 1)
                result[i] = new Vector2(transformedPoint[0], transformedPoint[1]);

                Debug.Log(string.Format("{0} : {1}", i , result[i]));
                lineRenderer.SetPosition(i, result[i]);
            }
        }
    }
}
