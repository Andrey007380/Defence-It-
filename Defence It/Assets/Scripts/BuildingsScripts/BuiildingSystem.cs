using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiildingSystem : MonoBehaviour
{ BulldingsGrid<GridObject> grid;
    [SerializeField] private List<Buldings> ListOfBuildings;
   private Buldings test;
    [SerializeField] private LayerMask mouseColliderLayerMask;
    private Buldings.Dir dir = Buldings.Dir.Down;
    private void Awake()
    {
        int gridWidth = 20;
        int gridHeight = 20;
        float cellSize = 4f;
        grid = new BulldingsGrid<GridObject>(gridWidth,gridHeight,cellSize,new Vector3(500,0,500),(BulldingsGrid<GridObject> g,int x,int y )=>new GridObject(g, x,y));
        test = ListOfBuildings[0];
    }
    class GridObject
    {
        private BulldingsGrid<GridObject> grid;
        private int x;
        private int y;
        private PlacedObjects placedObject;
        public void ClearPlacedObject()
        {
            placedObject = null;
            grid.GridTregger(x, y);
        }
        public void SetPlacedObject(PlacedObjects placedObjects)
        {
            placedObject = placedObjects;
            grid.GridTregger(x, y);
        }
        public PlacedObjects GetPlacedObject()
        {
            return placedObject;
        }
        public bool CanBuild()
        {
            return placedObject == null;
        }
        public GridObject(BulldingsGrid<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return x + " , " + y+ placedObject;
        }
    }
        private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            grid.GetXY(GetMosePosition(), out int x, out int y);
          List<Vector2Int> gridPositionList =  test.GetGridPosition(new Vector2Int(x, y), dir);
            Debug.Log(grid.GetWorldPosition(x, y));
            GridObject gridObject = grid.GetGridObject(x, y);
            bool CanBuild = true;
            foreach(Vector2Int gridPos in gridPositionList)
            {
                if (!grid.GetGridObject(gridPos.x, gridPos.y).CanBuild())
                {
                    CanBuild = false;
                    break;
                }
               
            }
            if (CanBuild )
            {
                Vector2Int rotatiomOffset = test.GetRotationOffset(dir);
                Vector3 placedObjectToWorld = grid.GetWorldPosition(x, y) + new Vector3(rotatiomOffset.x, 0, rotatiomOffset.y) * grid.GetCellSize() ;
                PlacedObjects placedObject = PlacedObjects.Create(placedObjectToWorld, new Vector2Int(x, y), dir, test);
                
                foreach (Vector2Int gridPos in gridPositionList)
                {
                    grid.GetGridObject(gridPos.x, gridPos.y).SetPlacedObject(placedObject);
                }
            }
            else
            {
                Debug.Log("Cant Build");
            }
             
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateBuild();
        }
    }
   public void  ChangeBuild() {
    }
    public void RotateBuild()
    {
        dir = Buldings.GetNextDir(dir);
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

