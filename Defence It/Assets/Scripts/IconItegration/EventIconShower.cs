using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventIconShower : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    [SerializeField] private Sprite arrowSprite;
    [SerializeField] private Sprite crossSprite;

    QuestPointer questPointer1;
    void Awake()
    {
        
    }

   
    void Update()
    {
        questPointer1.Update();
    }
    public QuestPointer CreatePointer(Vector3 tragetPosition,GameObject PointerPref)
    {
        GameObject PointerGameObject = Instantiate(PointerPref);
        PointerGameObject.transform.SetParent(transform, false);
        QuestPointer questPointer = new QuestPointer(tragetPosition,uiCamera, PointerPref, null, null);
        this.questPointer1 = questPointer;
        return questPointer;
    }
    public class QuestPointer
    {
        Vector3 targetPosition;
        GameObject PointerGameObject;
        Sprite arrowSprite;
        Sprite crossSprite;
        RectTransform pointRectTranform;
        Image pointerImage;
        public float BorderSize = 100f;
        private Camera uiCamera;
        public QuestPointer(Vector3 targetPosition,Camera camera,GameObject PointerGameObject,Sprite arrowSprite, Sprite crossSprite)
        {
            this.targetPosition = targetPosition;
            this.PointerGameObject = PointerGameObject;
            this.arrowSprite = arrowSprite;
            this.crossSprite = crossSprite;
            this.uiCamera = camera;

            pointRectTranform = PointerGameObject.GetComponent<RectTransform>();
            pointerImage = PointerGameObject.GetComponent<Image>();

        }
        public void Update()
        {
            Vector3 toPosition = new Vector3(targetPosition.x, targetPosition.z, targetPosition.y);
            Vector3 fromPosition = Camera.main.transform.position;
            fromPosition = new Vector3(fromPosition.x, fromPosition.z, fromPosition.y);
            Vector3 dir = (toPosition - fromPosition).normalized;
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            pointRectTranform.localEulerAngles = new Vector3(0, 0, angle);

            Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(toPosition);
            bool isOffScreen = targetPositionScreenPoint.x <= BorderSize || targetPositionScreenPoint.x >= Screen.width - BorderSize || targetPositionScreenPoint.y <= BorderSize || targetPositionScreenPoint.y >= Screen.height - BorderSize;

            if (isOffScreen)
            {
                Vector3 CappedTargetScreenPosition = targetPositionScreenPoint;
                CappedTargetScreenPosition.x = Mathf.Clamp(CappedTargetScreenPosition.x, BorderSize, Screen.width - BorderSize);
                CappedTargetScreenPosition.y = Mathf.Clamp(CappedTargetScreenPosition.y, BorderSize, Screen.height - BorderSize);

                Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(CappedTargetScreenPosition);
                pointRectTranform.position = pointerWorldPosition;
                pointRectTranform.localPosition = new Vector3(pointRectTranform.localPosition.x, pointRectTranform.localPosition.y, 0);

            }
            else
            {
                Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);

                pointRectTranform.position = pointerWorldPosition;

                pointRectTranform.localPosition = new Vector3(pointRectTranform.localPosition.x, pointRectTranform.localPosition.y, 1);
            }
        }
    }
}

