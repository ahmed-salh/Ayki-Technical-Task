using System;
using UnityEngine;
using UnityEngine.UI;

public class PlacementManager : MonoBehaviour
{

    public Action SnapEvent;

    public Action UnsnapEvent;

    [SerializeField]
    private RectTransform _canvas;

    [SerializeField]
    private RectTransform _container;

    private Vector2 _position;

    public Transform tempObject;

    private Camera _mainCam;

    public bool isDragging;

    private static PlacementManager _instance;

    public static PlacementManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlacementManager>();
                if (_instance == null)
                {
                    _instance = new GameObject(nameof(PlacementManager)).AddComponent<PlacementManager>();
                }

                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }

    private void Start()
    {
        _mainCam = Camera.main;
    }

    public void TempPlace(GameObject item)
    {
        isDragging = true;

        tempObject = Instantiate(item, Input.mousePosition, Quaternion.identity, _container).transform;

        tempObject.gameObject.GetComponent<Image>().raycastTarget = false;

    }

    public void PlaceItem()
    {
        isDragging = false;

        tempObject.gameObject.GetComponent<Image>().raycastTarget = true;

        tempObject = null;
    }

    private void Update()
    {
        if (isDragging && tempObject != null)
        {
            FollowMousePosition();
        }
    }


    public void FollowMousePosition() 
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas, Input.mousePosition, _mainCam,out _position);

        tempObject.position = _canvas.transform.TransformPoint(_position);
    }

    public void SnapToObject(Transform parent) 
    {
        tempObject.SetParent(parent);

        if (SnapEvent != null)
            SnapEvent.Invoke();
    }

    public void UnsnapObject() 
    {
        tempObject.SetParent(_container);

        if (UnsnapEvent != null)
            UnsnapEvent.Invoke();
    }
}
