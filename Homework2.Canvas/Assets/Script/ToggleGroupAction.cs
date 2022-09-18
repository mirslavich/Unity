using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class ToggleGroupAction : ToggleGroup
{
    [SerializeField] private TextMeshProUGUI someProUgui;
    private delegate void ChangedEventHandler(Toggle newActive);
    private event ChangedEventHandler OnChange;

    protected override void Start()
    {
        foreach (Transform transformToggle in gameObject.transform)
        {
            var toggle = transformToggle.gameObject.GetComponent<Toggle>();
            toggle.onValueChanged.AddListener((isSelected) => {
                if (!isSelected)
                {
                    return;
                }
                var activeToggle = Active();
                DoOnChange(activeToggle);
                someProUgui.text = activeToggle.name;
            });
        }
    }
    private Toggle Active()
    {
        return ActiveToggles().FirstOrDefault();
    }

    private  void DoOnChange(Toggle newActive)
    {
        var handler = OnChange;
        if (handler != null)
        {
            handler(newActive);
        }
    }
}