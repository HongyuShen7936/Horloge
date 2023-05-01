using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Dropdown dropdown;

    void Start()
    {
        dropdown = this.transform.GetChild(0).GetComponent<Dropdown>();

        dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(dropdown);
        });
    }


    void DropdownValueChanged(Dropdown change)
    {
        if (change.value == 0)
            LevelObjectManager.timeSourceId = 0;
        else if (change.value == 1)
            LevelObjectManager.timeSourceId = 1;
        else if (change.value == 2)
            LevelObjectManager.timeSourceId = 2;
    }
}