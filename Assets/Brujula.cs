using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brujula : MonoBehaviour
{
    public enum Direction { N, NE, E, SE, S, SW, W, NW}; //Lista de puntos cardinales ordenado en sentido horario
    Direction myDirection = Direction.N; //Variable para poder refrescar mi direccion
    private int angle = 0; //Numero de grados que van a los puntos cardinales
    private void Update()
    {
        //Aprovechando el orden de la declaracion los enunms podemos utilizar ++ o -- para movernos entre direcciones
        //Sentido antihorario
        if (Input.GetKeyDown(KeyCode.LeftArrow))//45º antihorario
        {
            myDirection--;
            resetCounterClockwiseDirection();
            CardinalPoints();
            RefreshDirection();
        }
        //Sentido horario
        else if (Input.GetKeyDown(KeyCode.RightArrow))//45º horario
        {
            myDirection++;
            resetCounterClockDirection();
            CardinalPoints();
            RefreshDirection();
        }
        //Sentido antihorario
        else if (Input.GetKeyDown(KeyCode.A))//90º antihorario
        {
            myDirection--;
            resetCounterClockwiseDirection();
            myDirection--;
            resetCounterClockwiseDirection();
            CardinalPoints();
            RefreshDirection();
        }
        //Sentido horario
        else if (Input.GetKeyDown(KeyCode.D))//90º horario
        {
            myDirection++;
            resetCounterClockDirection();
            myDirection++;
            resetCounterClockDirection();
            CardinalPoints();
            RefreshDirection();
        }
    }
    //CardinaPoint, ejecuta switch que a su vez guarda todos los puntos cardinales con su respectivo angulo
    public void CardinalPoints()
    {
        switch (myDirection)
        {
            case Direction.N:
                Debug.Log("N");
                angle = 0;
                break;
            case Direction.NE:
                Debug.Log("NE");
                angle = 315;
                break;
            case Direction.E:
                Debug.Log("E");
                angle = 270;
                break;
            case Direction.SE:
                Debug.Log("SE");
                angle = 225;
                break;
            case Direction.S:
                Debug.Log("S");
                angle = 180;
                break;
            case Direction.SW:
                Debug.Log("SW");
                angle = 135;
                break;
            case Direction.W:
                Debug.Log("W");
                angle = 90;
                break;
            case Direction.NW:
                Debug.Log("NW");
                angle = 45;
                break;
        }
    }
    public void RefreshDirection()//Refresca la rotacion visual de nuestra brujula
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    //Si la 2 siguiente funciones, la brujula solo daria una vuelta
    //Los enum funcionan como una lista N principio y NW final
    public void resetCounterClockwiseDirection()//Antihorario
    {
        if (myDirection < Direction.N)
        {
            myDirection = Direction.NW;
            Debug.Log("Comprobacion Antihoraria");
        }
    }
    public void resetCounterClockDirection()//horario
    {
        if (myDirection > Direction.NW)
        {
            myDirection = Direction.N;
            Debug.Log("Comprobacion Horaria");
        }
    }
}