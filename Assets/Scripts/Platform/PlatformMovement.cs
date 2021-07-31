using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TP Final - Juan Cruz Cristófalo
public class PlatformMovement : MonoBehaviour
{
    
    //Creamos un array de Vector3 publico que va a mostrar cuales son los puntos entre los que se tiene que mover la plataforma.
    public  Vector3[] points;
    public  int       point_number = 0;
    private Vector3   current_target;

    
    public float tolerance; //Tolerance lo vamos a usar para que la plataforma se mueva de manera limpia de punto en punto.
    public float speed; //Speed va a indicar la velocidad en la que la plataforma se mueve.
    public float delay_time; //Delay_Time va a ser utilizado para el delay que tiene entre movimientos la plataforma.

    private float delay_start;

    public bool automatic; //automatic es para que las plataformas se muevan de manera automática.

    void Start()
    {
        //Si creamos puntos, la plataforma va a lockear el primero para que sea el destino
        if(points.Length > 0)
        {
         current_target = points[0];
        }
        
        tolerance = speed * Time.deltaTime;
        
    }

    
    void Update()
    {
        //Si no está en el target, la plataforma se va a mover.
        if (transform.position != current_target)
        {
            MovePlatform();
        }
        //Y si lo está, le vamos a actualizar el target.
        else
        {
            UpdateTarget();
        }
        
    }

    void MovePlatform()
    {
        //Creamos un nuevo Vector3 para decirle a donde se dirige.
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;

        //Generamos que la plataforma se ajuste perfecto al punto donde queremos.
        if(heading.magnitude < tolerance)
        {
            transform.position = current_target;
            delay_start = Time.time;
        }
    }

    void UpdateTarget()
    {
        //Si se mueve automaticamente, nos fijamos si necesita moverse la plataforma.
        if (automatic)
        {
            if(Time.time - delay_start > delay_time)
            {
                NextPlatform();
            }
        }

    }

    public void NextPlatform()
    {

        point_number++;
        
        //Lo generamos por si no vamos a automatizar el movimiento.
        if (point_number >= points.Length)
        {
            point_number = 0;
        }

        current_target = points[point_number];
    }

   
}
