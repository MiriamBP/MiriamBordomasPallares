using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Zona de varibales globales
    [Header("IMAGES")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;

    [Header("FADE")]
    //Duración del fade
    [SerializeField]
    private float _fadeDuration;
    //Tiempo total de la imagen el pantalla
    [SerializeField]
    private float _displayImageDuration;
    //Crono
    private float _timer;

    //Para saber si John llegó al final
    public bool IsPlayerAtExit;
    //Para saber si pillaron a John
    public bool IsPlayerCaught;
    //Resetar nivel
    private bool _isRestatLevel;

    [Header("AUIDO")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;
    private AudioSource _audioSource;

    [Header("END")]
    [SerializeField]
    private GameObject _panelWon;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerAtExit)
        {
            Won();
        }
        else if (IsPlayerCaught)
        {
            Caught();
        }
    }

    private void Won()
    {
        _audioSource.clip = _wonClip;
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        _timer = _timer + Time.deltaTime;
        //Aumentar opacidad de la imagen
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer / _fadeDuration);

        _panelWon.SetActive(true);

    }

    private void Caught()
    {
        _audioSource.clip = _caughtClip;
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        _timer = _timer + Time.deltaTime;
        //Aumentar opacidad de la imagen
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g, _caughtImage.color.b, _timer / _fadeDuration);

        if (_timer > _fadeDuration + _displayImageDuration)
        {
            SceneManager.LoadScene("JohnLemon");
        }
    }

    public void LoadSceneButton()
    {
        SceneManager.LoadScene("JohnLemon");
    }
}
