using UnityEngine;
using UnityEngine.UI;

public class ScreenSwitch : MonoBehaviour
{
    [SerializeField] private GameObject generalScreen;

    private GameObject currentScreen;

    protected virtual void Start()
    {
        var button = GetComponent<Button>();
        currentScreen = transform.parent.parent.gameObject;

        if (button == null || currentScreen == null)
        {
            Debug.Log("I got NULL ");
            Application.Quit();
        }

        button.onClick.AddListener(delegate { currentScreen.SetActive(false); generalScreen.SetActive(true); });
    }
}