using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public readonly Vector3[] lookPoints;
    public readonly Line[] turnBoundaries;
    public readonly int finishLineIndex;
    public readonly int slowDownIndex;

    public Path(Vector3[] waypoints, Vector3 startPosition, float turnDistance, float stoppingDist)
    {
        lookPoints = waypoints;
        turnBoundaries = new Line[lookPoints.Length];
        finishLineIndex = turnBoundaries.Length - 1;

        Vector2 previousPoint = V3ToV2(startPosition);
        for (int i=0; i < lookPoints.Length; i++)
        {
            Vector2 currentPoint = V3ToV2(lookPoints[i]);
            Vector2 dirToCurrentPoint = (currentPoint - previousPoint).normalized;
            Vector2 turnBoudaryPoint = (i==finishLineIndex)?currentPoint: currentPoint - dirToCurrentPoint * turnDistance;
            turnBoundaries[i] = new Line(turnBoudaryPoint, previousPoint - dirToCurrentPoint * turnDistance);
            previousPoint = turnBoudaryPoint;

            //Vector2 turnBoundaryPoint = (i == finishLineIndex) ? currentPoint : currentPoint - dirToCurrentPoint * turnDistance;
        }

        float distFromEndPoint = 0;
        for(int i = lookPoints.Length - 1; i > 0; i--)
        {
            distFromEndPoint += Vector3.Distance(lookPoints[i], lookPoints[i - 1]);
            if(distFromEndPoint > stoppingDist)
            {
                slowDownIndex = i;
                break;
            }
        }
    }

    Vector2 V3ToV2(Vector3 v3)
    {
        return new Vector2(v3.z, v3.y);
    }

    public void DrawWithGizmos()
    {
        Gizmos.color = Color.black;
        foreach(Vector3 point in lookPoints)
        {
            Gizmos.DrawCube(point + Vector3.up, Vector3.one);
        }

        Gizmos.color = Color.white;
        foreach(Line line in turnBoundaries)
        {
            line.DrawWithGizmos(10);
        }
    }
}
