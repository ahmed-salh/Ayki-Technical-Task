using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceSurface : MonoBehaviour, IPointerDownHandler
{

    public Action PlacementEvent;


    public void OnPointerDown(PointerEventData eventData)
    {
        if ((PlacementManager.Instance.isDragging || PlacementManager.Instance.tempObject != null) && eventData.button == PointerEventData.InputButton.Left)
        {
            if (PlacementEvent != null)
                PlacementEvent.Invoke();

            PlacementManager.Instance.PlaceItem();
        }

        if (Transformation.Instance.isRotating && eventData.button == PointerEventData.InputButton.Right)
        {

            Transformation.Instance.isRotating = false;

            Transformation.Instance.selectedObject = null;
        }
    }
}
