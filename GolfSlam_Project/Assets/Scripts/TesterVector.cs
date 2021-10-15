using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterVector : MonoBehaviour
{
    void Start()
    {
        ClaseVector vectorPau = new ClaseVector();
        Debug.Log("El vector de Pau es: " +vectorPau.X +", " +vectorPau.Y +", " +vectorPau.Z +" Magnitud= " +vectorPau.Magnitud());
        vectorPau = new ClaseVector(2,3,2);
        Debug.Log("El vector de Pau es: " + vectorPau.X + ", " + vectorPau.Y + ", " + vectorPau.Z + " Magnitud= " + vectorPau.Magnitud());
        //vectorPau = new ClaseVector(1, 2, 3, 4);
        //Debug.Log("El vector de Pau es: " + vectorPau.X + ", " + vectorPau.Y + ", " + vectorPau.X + " Magnitud= " + vectorPau.Magnitud());

        /*try
        {
            vectorPau = new ClaseVector(90, 56, 43, 2);
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }*/

        vectorPau.Normalize();
        Debug.Log("El vector de Pau es: " + vectorPau.X + ", " + vectorPau.Y + ", " + vectorPau.Z + " Magnitud= " + vectorPau.Magnitud());

        vectorPau = new ClaseVector(1, 4, 2);
        vectorPau.Reverse();
        Debug.Log("El vector de Pau es: " + vectorPau.X + ", " + vectorPau.Y + ", " + vectorPau.Z + " Magnitud= " + vectorPau.Magnitud());

        ClaseVector vectorSuma = vectorPau.Suma(new ClaseVector(1, 3, 5));

        //ClaseVector vectorSuma2 = ClaseVector.Suma2(new ClaseVector(1, 3, 5), new ClaseVector(0, 2, 4));

        ClaseVector vector1 = new ClaseVector(1, 3, 5);
        ClaseVector vector2 = new ClaseVector(0, 2, 4);
        ClaseVector totalsumas = vector1 + vector2;
        Debug.Log("El vector sumado de Pau es: " + totalsumas.ToString());

        ClaseVector vector3 = new ClaseVector(1, 3, 5);
        ClaseVector vector4 = new ClaseVector(0, 2, 4);
        ClaseVector totalrestas = vector3 - vector4;
        Debug.Log("El vector restado de Pau es: " + totalrestas.ToString());

        ClaseVector vector5 = new ClaseVector(1, 2, 3);
        float multiplicador = 2f;
        ClaseVector multfloat = vector5 * multiplicador;
        Debug.Log("El vector multiplicado por un float de Pau es: " + multfloat.ToString());

        ClaseVector vector6 = new ClaseVector(2, 2, 2);
        ClaseVector vector7 = new ClaseVector(1, 2, 3);
        float productoescalar = vector6 * vector7;
        Debug.Log("El producto escalar de Pau es: " + productoescalar);

        ClaseVector vector8 = new ClaseVector(3, 1, 3);
        ClaseVector vector9 = new ClaseVector(1, 2, 3);
        ClaseVector productovectorial = vector8 ^ vector9;
        Debug.Log("El vector multiplicado por un float de Pau es: " + productovectorial.ToString());
    }
   
    void Update()
    {
        
    }
}
