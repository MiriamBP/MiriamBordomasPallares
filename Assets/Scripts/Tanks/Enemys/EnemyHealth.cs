using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
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
    private float _damagePlayerBullets;

    [Header("EXPLOSIONS")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    [Header("PROGRESS BAR")]
    [SerializeField]
    private Image _lifeBar;

    private void Awake()
    {
        _bigExplosion.Stop();
        _smallExplosion.Stop();
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;
    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("PlayerBullets"))
        {
            _smallExplosion.Play();
            _currentHealth -= _damagePlayerBullets;
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
        Destroy(gameObject, 1.0f);
    }
}
