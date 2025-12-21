using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIManager : MonoBehaviour
{

    public TMP_InputField inputField;

    private void Start()
    {
        // Подставляем сохранённый текст при открытии меню
        if (MainManager.Instance != null)
        {
            inputField.text = MainManager.Instance.GetPlayerText();
        }
    }
    public void OnInputChanged()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SetPlayerText(inputField.text);
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
       
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
