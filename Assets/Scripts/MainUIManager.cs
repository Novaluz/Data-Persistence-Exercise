
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameUI : MonoBehaviour
{
    public Text nameText;

    void Start()
    {
        nameText.text = MainManager.Instance.GetPlayerText();
    }
}
