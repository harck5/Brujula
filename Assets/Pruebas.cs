using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    private enum Direction { N, S, E, W, NE, NW, SE, SW }

    private Direction direction;

    private int angle;

    private int anglePush = 45;

    private void Awake()
    {
        transform.eulerAngles = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateOnClock(anglePush);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateCounterClock(anglePush);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RotateOnClock(anglePush * 2);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            RotateCounterClock(anglePush * 2);
        }

        // Aplicar la rotaci�n
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void RotateOnClock(int degrees)
    {
        angle = (angle + degrees) % 360;
        RefreshDirection();
    }

    private void RotateCounterClock(int degrees)
    {
        angle = (angle - degrees + 360) % 360;
        RefreshDirection();
    }

    private void RefreshDirection()
    {
        // Actualizar la direcci�n basada en el �ngulo actual
        int octant = (angle + 360) % 360 / 45;
        direction = (Direction)octant;
    }
}
