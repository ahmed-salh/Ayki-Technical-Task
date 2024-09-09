using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{

    private static Transformation _instance;

    public static Transformation Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Transformation>();
                if (_instance == null)
                {
                    _instance = new GameObject(nameof(Transformation)).AddComponent<Transformation>();
                }

                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }

    public Transform selectedObject;

    public bool isRotating = false;

    void Update()
    {
        if (isRotating)
        {   
            Vector3 mousePos = Input.mousePosition;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(selectedObject.transform.position);

            mousePos.x = mousePos.x - objectPos.x;

            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            selectedObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
}
