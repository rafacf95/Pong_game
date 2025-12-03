using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JoinSecondPlayer : MonoBehaviour
{
    public GameObject inputField;
    public void JoinGame()
    {
        SaveController.Instance.ToggleSecondPlayer();
        inputField.SetActive(SaveController.Instance.secondPlayer);

        ChangeText(SaveController.Instance.secondPlayer);
    }

    private void ChangeText(bool secondPlayer)
    {
        if (secondPlayer)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Leave";
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Join";
        }
    }

    void Start()
    {
        ChangeText(SaveController.Instance.secondPlayer);
    }
}
