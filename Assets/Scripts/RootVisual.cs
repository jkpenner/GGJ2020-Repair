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

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    public void SetConnection(RootVisual visual, int connectedIndex)
    {
        this.Previous = visual;
        this.ConnectedIndex = connectedIndex;
        if (this.Previous != null)
        {
            this.line.sortingOrder = this.Previous.GetSortingOrder() - 1;
        }
    }

    private int GetSortingOrder()
    {
        return this.line.sortingOrder;
    }

    public bool CheckForCollision(Vector2 position, float radius)
    {
        for (var i = 0; i < line.positionCount - 1 - 2; i++)
        {
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
        if (index <= 0)
        {
            return (Previous, ConnectedIndex);
        }
        else
        {
            return (this, index - 1);
        }
    }

    public Vector2 GetPosition(int index)
    {
        if (index >= 0 && index < line.positionCount)
            return line.GetPosition(index);
        else if(index > line.positionCount - 1)
            return line.GetPosition(line.positionCount - 1);
        else
            return Vector2.zero;
    }

    public int GetPointCount()
    {
        return line.positionCount;
    }

    public float GetDistanceToStart(int index) {
        (RootVisual previous, int prevIndex) = GetPreviousPoint(index);
        if (previous == null)
            return 0f;

        Vector2 position = GetPosition(index);
        Vector2 other = previous.GetPosition(index);

        return Vector2.Distance(position, other) + previous.GetDistanceToStart(prevIndex);
    }
}
