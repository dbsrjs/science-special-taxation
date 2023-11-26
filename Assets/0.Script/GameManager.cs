using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int timeSize = 1;

    void Update()
    {
        Time.timeScale = timeSize;
    }

    public void GameStart() //���� ����
    {
        timeSize = 1;
    }

    public void GameStop()  //���� ����
    {
        timeSize = 0;
    }
}
