using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTanks : MonoBehaviour
{
    //Zona de variables globales
    [Header("GAME OVER")]
    [SerializeField]
    private GameObject _panelGameOver;
    [SerializeField]
    private EnemyManager _enemyManager;

    public void GameOver()
    {
        //Activar panel GameOver
        _panelGameOver.SetActive(true);
        //Desactivar componente EnemyManager
        _enemyManager.enabled = false;
    }

    public void LoadSceneLevel()
    {
        SceneManager.LoadScene(0);
    }
}
