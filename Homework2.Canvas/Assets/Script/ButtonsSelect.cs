using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSelect : MonoBehaviour
{
    [SerializeField] private Button buttonOne;
    [SerializeField] private Button buttonTwo;
    [SerializeField] private Button buttonDisable;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    void Start()
    {
        PrintButtonName(buttonOne);
        PrintButtonName(buttonTwo);

        if (buttonDisable == null)
        {
            Debug.Log($"{buttonDisable} not found!");
            Application.Quit();
        }
        else
        {
            buttonDisable.onClick.AddListener(() =>
            {
                DisableButton(buttonOne);
                DisableButton(buttonTwo);
                DisableButton(buttonDisable);
            });
        }
    }

    private void PrintButtonName(Button someButton)
    {
        if (someButton==null)
        {
            Debug.Log($"{someButton} not found!");
            Application.Quit();
        }
        else
        {
            someButton.onClick.AddListener(() => { textMeshPro.text = someButton.name + " Clicked"; });
        }
    }

    private void DisableButton(Button someButton)
    {
        someButton.interactable = false;
    }

    

}
