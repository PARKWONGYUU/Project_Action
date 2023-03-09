using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour
{
    public Button gameStart;

    public void GameStartBtn()
    {
        SceneManager.LoadScene(1);
    }
}
