using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectItem : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!PlacementManager.Instance.isDragging && PlacementManager.Instance.tempObject == null && eventData.button == PointerEventData.InputButton.Right) 
        {

            if (gameObject.transform.parent.CompareTag("Greenhouse"))
                return;

            Transformation.Instance.selectedObject = gameObject.transform;

            Transformation.Instance.isRotating = true;
        }
    }

}
