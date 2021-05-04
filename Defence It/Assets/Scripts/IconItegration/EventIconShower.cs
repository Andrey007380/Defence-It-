using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventIconShower : MonoBehaviour
{
    [SerializeField]private Camera uiCamera;
    public Vector3 targetPosition;
    public float BorderSize = 100f;
    private RectTransform pointRectTranform;
    public GameObject Pointer;
    void Awake()
    {
        targetPosition = new Vector3(500, 0, 500);
        pointRectTranform = Pointer.GetComponent<RectTransform>();
    }

   
    void Update()
    {
        Vector3 toPosition = new Vector3( targetPosition.x,targetPosition.z,targetPosition.y);
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition = new Vector3(fromPosition.x, fromPosition.z, fromPosition.y);
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) ;
        pointRectTranform.localEulerAngles = new Vector3(0, 0, angle);
         
         Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(toPosition);
         bool isOffScreen = targetPositionScreenPoint.x <= BorderSize || targetPositionScreenPoint.x >= Screen.width - BorderSize || targetPositionScreenPoint.y <= BorderSize || targetPositionScreenPoint.y >= Screen.height - BorderSize;
         
         if (isOffScreen)
         {
             Vector3 CappedTargetScreenPosition = targetPositionScreenPoint;
             if (CappedTargetScreenPosition.x <= BorderSize) CappedTargetScreenPosition.x = BorderSize;
            if (CappedTargetScreenPosition.y <= BorderSize) CappedTargetScreenPosition.y = BorderSize;
            if (CappedTargetScreenPosition.x >= Screen.width - BorderSize) CappedTargetScreenPosition.x = Screen.width - BorderSize;
            if (CappedTargetScreenPosition.y >= Screen.height - BorderSize) CappedTargetScreenPosition.y = Screen.height - BorderSize;
             Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(CappedTargetScreenPosition);
             pointRectTranform.position = pointerWorldPosition;
             pointRectTranform.localPosition = new Vector3(pointRectTranform.localPosition.x, pointRectTranform.localPosition.y, 0);

         }
         else
         { 
             Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
            
             pointRectTranform.position = pointerWorldPosition;

        pointRectTranform.localPosition =  new Vector3(pointRectTranform.localPosition.x, pointRectTranform.localPosition.y, 1);
        }
    }
}

