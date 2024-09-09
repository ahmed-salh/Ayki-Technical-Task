using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoScaleBeds : MonoBehaviour
{
    private VerticalLayoutGroup _layout;

    private void Start()
    {
        _layout = GetComponent<VerticalLayoutGroup>();
    }

    private void OnEnable()
    {
        PlacementManager.Instance.SnapEvent += EnableAutoScale;

        PlacementManager.Instance.UnsnapEvent += DisableAutoScale;
    }

    public void EnableAutoScale() 
    {
        if (transform.childCount > 2)
            _layout.childControlHeight = true;
        
    }

    public void DisableAutoScale()
    {
        if (transform.childCount <= 2)
            _layout.childControlHeight = false;
       
    }

    private void OnDisable()
    {
        PlacementManager.Instance.SnapEvent -= EnableAutoScale;

        PlacementManager.Instance.UnsnapEvent -= DisableAutoScale;

    }
}
