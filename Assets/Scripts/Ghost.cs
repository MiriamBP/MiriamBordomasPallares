using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //Zona de variables globales
    //Array de posiciones para el fantasma
    [Header("WAYPOINTS")]
    [SerializeField]
    private Transform[] _positionsArray;
    [SerializeField]
    private int _speed;
    //Almacenar la posición a la que se dirige el fantasma
    private Vector3 _posToGo;
    //Controlar en que posición del array estoy
    private int _i;
    //Detectar a John
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        _i = 0;
        _posToGo = _positionsArray[_i].position;
    }

    private void FixedUpdate()
    {
        DetectionJohnLemon();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangePosition();
        Rotate();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime);
    }

    private void ChangePosition()
    {
        //Si es fantasma llega a su destino
        if(Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {
            //Comprobar si el fantasma está en la última posición del array
            if(_i == _positionsArray.Length - 1)
            {
                //Vuelve a la primera posición
                _i = 0;
            }
            else
            {
                _i++;
            }

            _posToGo = _positionsArray[_i].position;
        }
    }

    private void Rotate()
    {
        transform.LookAt(_posToGo);
    }

    private void DetectionJohnLemon()
    {
        //Subir el rayo y decir hacia donde va
        _ray.origin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;

        if(Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.CompareTag("JohnLemon"))
            {
                GameManagerScript.IsPlayerCaught = true;
            }
        }
    }
}

