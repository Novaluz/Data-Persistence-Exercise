using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIManager : MonoBehaviour
{
    //код для поля ввода имени игрока
    public TMP_InputField inputField;
    // лучший результат
    public TMP_Text bestScoreText;


    private void Start()
    {
        if (MainManager.Instance != null)
        {
            // имя игрока
            inputField.text = MainManager.Instance.GetPlayerText();

            // лучший результат
            //bestScoreText.text = MainManager.Instance.GetBestScoreText();
        }
        Debug.Log("Menu Start, BestScoreText from MM = "
    + MainManager.Instance.GetBestScoreText());
    }

    public void OnInputChanged()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SetPlayerText(inputField.text);
        }
    }

    //код для кнопки старта новой игры и выхода из игры
    public void StartNew()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SetPlayerText(inputField.text);
        }
        Debug.Log("Имя перед стартом: " + inputField.text);

        SceneManager.LoadScene(1);
    }

    private void OnEnable()
    {
        UpdateBestScoreUI();
    }

    private void UpdateBestScoreUI()
    {
        if (MainManager.Instance == null || bestScoreText == null)
            return;

        bestScoreText.text = MainManager.Instance.GetBestScoreText();
    }

    public void ResetBestScore()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.ResetBestScore();
            UpdateBestScoreUI();
        }
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
