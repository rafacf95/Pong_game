using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetData : MonoBehaviour
{
    public void ClearData()
    {
        SaveController.Instance.ClearSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
