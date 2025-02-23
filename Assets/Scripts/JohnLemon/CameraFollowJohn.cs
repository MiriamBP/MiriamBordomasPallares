using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJohn : MonoBehaviour
{
    //Zona de variables globales
    public Transform Target;
    [Header("VECTORS")]
    //Velocidad de movimiento de la cámara
    [SerializeField]
    private float _smoothing;
    //Distancia inicial entre la cámara y John
    [SerializeField]
    private Vector3 _offset;


    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        //Posición a la que queremos mover la cámara
        Vector3 desiredPosition = Target.position + _offset;
        //Mover la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);
    }
}
