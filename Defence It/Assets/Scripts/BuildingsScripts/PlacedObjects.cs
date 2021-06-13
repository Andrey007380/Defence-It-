using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObjects : MonoBehaviour
{ public static PlacedObjects Create(Vector3 worldPosition,Vector2Int orgin,Buldings.Dir dir,Buldings BuildingType)
    {
        Transform PlasedObjTransform = Instantiate(BuildingType.prefab, worldPosition, Quaternion.Euler(0, BuildingType.GetRotationAngle(dir), 0));
        PlacedObjects placedObject = PlasedObjTransform.GetComponent<PlacedObjects>();
        placedObject.placedBuild = BuildingType;
        placedObject.origin = orgin;
        placedObject.dir = dir;
        return placedObject;
        
    }
    private Buldings placedBuild;
    private Vector2Int origin;
    private Buldings.Dir dir;


}
