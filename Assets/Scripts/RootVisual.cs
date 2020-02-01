using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RootVisual : MonoBehaviour
{
    public RootVisual Previous { get; private set; }
    public int ConnectedIndex { get; private set; }

    private LineRenderer line;

    private void Awake() {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    public void SetConnection(RootVisual visual, int connectedIndex) 
    {
        this.Previous = visual;
        this.ConnectedIndex = connectedIndex;
    }
    
    public bool CheckForCollision(Vector2 position, float radius)
    {
        for(var i = 0; i < line.positionCount - 1 - 2; i++) {
            if (Vector2.Distance(line.GetPosition(i), position) < 0.5f)
            {
                return true;
            }
        }
        return false;
    }

    public void UpdateLastPosition(Vector2 position)
    {
        if (line.positionCount > 0)
            line.SetPosition(line.positionCount - 1, (Vector3)position);
    }

    public void AddPoint(Vector3 position)
    {
        line.positionCount = line.positionCount + 1;
        line.SetPosition(line.positionCount - 1, (Vector3)position);   
    }

    public (RootVisual, int) GetPreviousPoint(int index)
    {
        if (index <= 0) {
            return (Previous, ConnectedIndex);
        } else {
            return (this, index - 1);
        }
    }

    public Vector2 GetPosition(int index)
    {
        return line.GetPosition(index);
    }

    public int GetPointCount() {
        return line.positionCount;
    }
}
