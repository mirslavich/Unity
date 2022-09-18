using TMPro;
using UnityEngine;

public class DropDownText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private TMP_Dropdown dropdown;

    void Start()
    {
        if (dropdown == null || textMeshPro==null)
        {
            Debug.Log("Here is NULL");
            Application.Quit();
        }
        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown);});
    }

    private void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        textMeshPro.text= dropdown.options[index].text;
    }
}
