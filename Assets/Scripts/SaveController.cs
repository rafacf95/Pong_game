using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    public string namePlayer;
    public string nameEnemy;
    public bool secondPlayer = false;
    public string botName = "Bot";

    private static SaveController _instance;

    private string savedWinnerKey = "SavedWinner";

    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = secondPlayer ? "" : botName;
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
        
        GameObject.Find("SecondPlayerInput").SetActive(secondPlayer);
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(savedWinnerKey, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(savedWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ToggleSecondPlayer()
    {
        if (secondPlayer == false)
        {
            secondPlayer = true;
        }
        else
        {
            SaveController.Instance.nameEnemy = botName;
            secondPlayer = false;
        }
    }
}
