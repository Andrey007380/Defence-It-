using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BulldingsGrid<TGridObject>
{
    private int width;
    private int height;
    private float cellSize;
    private TGridObject[,] gridArray;
    private Vector3 originPosition;
    public event EventHandler<OnGridValueChanged> onGridValueChanged;
    public class OnGridValueChanged : EventArgs
    {
        public int x;
        public int y;
    }
    public BulldingsGrid(int width,int height,float cellSize,Vector3 originPosition,Func<BulldingsGrid<TGridObject>,int ,int, TGridObject> createGridobject)
    { this.width = width;
      this.height = height;
      this.cellSize = cellSize;
      this.originPosition = originPosition;


        bool DebugShow = true;
        if (DebugShow)
        {
            TextMesh[,] debugTextArray = new TextMesh[width, height];
            gridArray = new TGridObject[width, height];
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    gridArray[x, y] = createGridobject(this, x,y);
                    debugTextArray[x,y]= TextToWorld.CreateToWorld(gridArray[x, y]?.ToString(), Color.white, null, GetWorldPosition(x, y) + new Vector3(cellSize, 0, cellSize) * 0.5f, 15, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
                Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
                onGridValueChanged += (object sender, OnGridValueChanged EventArgs) =>
                  {
                      debugTextArray[EventArgs.x, EventArgs.y].text = gridArray[EventArgs.x, EventArgs.y].ToString();
                  };
            }
        }

    }
     public void GridTregger(int x , int y)
    {
        if (onGridValueChanged != null) onGridValueChanged(this, new OnGridValueChanged { x = x, y = y });
    }
     public void SetValue(int x , int y, TGridObject value)
    {if(x>=0&&y>=0 &&x<width && y < height)
        {
            gridArray[x, y] = value;
            if (onGridValueChanged != null) onGridValueChanged(this, new OnGridValueChanged { x = x, y = y });
        }

    }
    public void SetValue(Vector3 WorldPosition,TGridObject value)
    {
        int x, y;
        GetXY(WorldPosition, out x, out y);
        SetValue(x, y, value);
    }
    public TGridObject GetGridObject(int x ,int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else return default(TGridObject);
    }
   public TGridObject GetGridObject(Vector3 WorldPosition)
    {
        int x, y;
        GetXY(WorldPosition, out x, out y);
        return GetGridObject(x, y);
    }
    public void GetXY(Vector3 WorldPosition, out int x , out int  y)
    {
       
        x = Mathf.FloorToInt((WorldPosition.x - originPosition.x) / cellSize);
        y = Mathf.FloorToInt((WorldPosition.z - originPosition.z) / cellSize);
    
}
    public  Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,0, y) * cellSize + originPosition;
    }   
     public float GetCellSize()
    {
        return cellSize;
    }
}
