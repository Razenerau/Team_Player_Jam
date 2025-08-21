using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReferenceTilemap : MonoBehaviour
{
    public CompositeCollider2D SourceCollider;
    public PolygonCollider2D TargetCollider;
    public float OffsetY;

    void Awake()
    {
        //if (SourceCollider == null || TargetCollider == null) return;

        gameObject.transform.position = SourceCollider.transform.position;

        TargetCollider.pathCount = SourceCollider.pathCount;

        for (int i = 0; i < SourceCollider.pathCount; i++)
        {
            Vector2[] points = new Vector2[SourceCollider.GetPathPointCount(i)];
            SourceCollider.GetPath(i, points);
            TargetCollider.SetPath(i, points);
        }

        
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        Vector2 newPos = new Vector2(x, y + OffsetY);
        gameObject.transform.position = newPos; 
    }
}
