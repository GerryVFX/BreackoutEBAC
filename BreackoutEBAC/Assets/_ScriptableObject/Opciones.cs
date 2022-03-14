using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="Opciones", menuName ="Herramientas/Opciones", order =1)]
public class Opciones : PuntosPercistente
{
    public float ballSpeed = 30;
    public dificult levelDificult = dificult.easy;
    

    public enum dificult
    {
        easy, nomral, hard
    }

    public void ChangeSpeed(float newSpeed)
    {
        ballSpeed = newSpeed;
    }

    public void ChangeDificult(int newDificult)
    {
        levelDificult = (dificult)newDificult;

        GameObject ball = GameObject.FindGameObjectWithTag("ball");
        Ball ballF = ball.GetComponent<Ball>();

        if (levelDificult == dificult.easy)
        {
            ballF.ballForce = 3;
        }
        else if (levelDificult == dificult.nomral)
        {
            ballF.ballForce = 2;
        }
        else if (levelDificult == dificult.hard)
        {
            ballF.ballForce = 1;
        }
    }

    public void BallDificult()
    {
        
    }
}
