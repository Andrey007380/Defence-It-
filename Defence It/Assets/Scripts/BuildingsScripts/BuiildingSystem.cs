using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiildingSystem : MonoBehaviour
{ BulldingsGrid<GridObject> grid;
   [SerializeField]  private GameObject test;
    [SerializeField] private LayerMask mouseColliderLayerMask;
    private void Awake()
    {
        int gridWidth = 20;
        int gridHeight = 20;
        float cellSize = 4f;
        grid = new BulldingsGrid<GridObject>(gridWidth,gridHeight,cellSize,new Vector3(500,0,500),(BulldingsGrid<GridObject> g,int x,int y )=>new GridObject(g, x,y));
    }
    class GridObject
    {
        private BulldingsGrid<GridObject> grid;
        private int x;
        private int y;
        private Transform transform;
        public void ClearTranform()
        {
            transform = null;
            grid.GridTregger(x, y);
        }
        public void SetTranform(Transform position)
        {
            transform = position;
            grid.GridTregger(x, y);
        }
        public Transform GetTranform()
        {
            return transform;
        }
        public bool CanBuild()
        {
            return transform == null;
        }
        public GridObject(BulldingsGrid<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return x + " , " + y+transform;
        }
    }
        private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            grid.GetXY(GetMosePosition(), out int x, out int y);
            Debug.Log(grid.GetWorldPosition(x, y));
            GridObject gridObject = grid.GetGridObject(x, y);
            if (gridObject.CanBuild() )
            {
                Transform buildTranform= Instantiate(test, grid.GetWorldPosition(x, y), Quaternion.identity).transform;
                gridObject.SetTranform(buildTranform);
            }
            else
            {
                Debug.Log("Cant Build");
            }
             
        }

    }
        private Vector3 GetMosePosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderLayerMask))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
        }
    }

