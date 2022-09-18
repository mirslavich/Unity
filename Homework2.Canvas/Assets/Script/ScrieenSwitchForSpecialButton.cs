using UnityEngine;
using UnityEngine.UI;

public class ScrieenSwitchForSpecialButton : ScreenSwitch
{
    [SerializeField] private Button buttonOne;
    [SerializeField] private Button buttonTwo;
    [SerializeField] private Button buttonDisable;
    protected override void Start()
    {
        base.Start();
        var buttonBack = GetComponent<Button>();
        if (buttonBack == null)
        {
            Debug.Log("I got NULL ");
            Application.Quit();
        }
        buttonBack.onClick.AddListener(delegate {
            buttonOne.interactable = true;
            buttonTwo.interactable = true;
            buttonDisable.interactable = true;
        });
        


    }
}
