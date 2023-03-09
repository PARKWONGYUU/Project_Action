using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void GameStart()
    {
        //초기값 설정
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
        }
    }
}
