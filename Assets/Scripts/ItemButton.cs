using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    private Button _button;

    [SerializeField]
    private GameObject _item;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() => { PlacementManager.Instance.TempPlace(_item);});
    }
}
