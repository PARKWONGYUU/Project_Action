using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void GameStart()
    {
        //�ʱⰪ ����
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
        }
    }
}
