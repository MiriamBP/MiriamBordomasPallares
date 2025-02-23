using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    //Zona de variables globales
    [Header("HEALTH")]
    //Salud máxima
    [SerializeField]
    private float _maxHealth;
    //Salud actual
    [SerializeField]
    private float _currentHealth;
    //Daño de las balas enemigas
    [SerializeField]
    private float _damageEnemyBullets;

    [Header("EXPLOSIONS")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    [Header("PROGRESS BAR")]
    [SerializeField]
    private Image _lifeBar;

    [Header("GAME OVER")]
    [SerializeField]
    private GameManagerTanks _gameManager;

    private void Awake()
    {
        _bigExplosion.Stop();
        _smallExplosion.Stop();
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;
    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("EnemyBullets"))
        {
            _smallExplosion.Play();
            _currentHealth -= _damageEnemyBullets;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);

            if (_currentHealth <= 0.0f)
            {
                _bigExplosion.Play();
                Death();
            }
        }
    }

    private void Death()
    {
        _gameManager.GameOver();
        Camera.main.transform.SetParent(null);
        Destroy(gameObject, 1.0f);
    }
}
