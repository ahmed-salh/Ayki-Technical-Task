using UnityEngine;
using UnityEngine.EventSystems;

public class SnapObject : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (PlacementManager.Instance.tempObject == null || PlacementManager.Instance.tempObject.tag == "Greenhouse")
            return;

        if (PlacementManager.Instance.isDragging)
        {

            PlacementManager.Instance.isDragging = false;
            
            PlacementManager.Instance.SnapToObject(gameObject.transform);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (PlacementManager.Instance.tempObject == null || PlacementManager.Instance.tempObject.tag == "Greenhouse")
            return;

        if (!PlacementManager.Instance.isDragging) 
        {
            PlacementManager.Instance.UnsnapObject();

            PlacementManager.Instance.isDragging = true;
        }
    }
}
