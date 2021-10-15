using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseVector
{
    public float X;
    public float Y;
    public float Z;

    #region constructores
    public ClaseVector()
    {
        X = 0;
        Y = 0;
        Z = 0;
    }

    public ClaseVector(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public ClaseVector(float AngleX, float AngleY, float AngleZ, float lenght)
    {
        //float checkDirectionCosines = Mathf.Cos(AngleX) + Mathf.Cos(AngleX) * Mathf.Cos(AngleY) + Mathf.Cos(AngleY) * Mathf.Cos(AngleZ) + Mathf.Cos(AngleZ);
        float checkDirectionCosines = Mathf.Pow(Mathf.Cos(AngleX), 2) + Mathf.Pow(Mathf.Cos(AngleY), 2) + Mathf.Pow(Mathf.Cos(AngleZ), 2);
        if(checkDirectionCosines > 0.999f && checkDirectionCosines < 1.001f)
        {
            this.X = lenght * Mathf.Cos(AngleX);
            this.Y = lenght * Mathf.Cos(AngleY);
            this.Z = lenght * Mathf.Cos(AngleZ);
        }
        else
        {
            throw new System.FormatException("Wrong Direction Angles");
        }
    }
    #endregion

    #region metodos
    public float Magnitud()
    {
        float magnitud = Mathf.Sqrt(X * X + Y * Y + Z * Z);
        return magnitud;
    }

    public void Normalize()
    {
        float magnitud = this.Magnitud();
        if(magnitud != 0)
        {
            X = X / magnitud;
            Y = Y / magnitud;
            Z = Z / magnitud;
        }
    }

    public void Reverse()
    {
        X = -X;
        Y = -Y;
        Z = -Z;
    }

    public ClaseVector Suma(ClaseVector a)
    {
        ClaseVector suma = new ClaseVector(X + a.X, Y + a.Y, Z + a.Z);
        return suma;
    }
    #region operacionesMetodos
    public static ClaseVector operator +(ClaseVector a, ClaseVector b)
    {
        ClaseVector suma = new ClaseVector(b.X + a.X, b.Y + a.Y, b.Z + a.Z);
        return suma;
    }

    public static ClaseVector operator -(ClaseVector a, ClaseVector b)
    {
        ClaseVector resta = new ClaseVector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        return resta;
    }

    public static ClaseVector operator *(ClaseVector a, float b)
    {
        ClaseVector multfloat = new ClaseVector(b * a.X, b * a.Y, b * a.Z);
        return multfloat;
    }

    public static ClaseVector operator /(ClaseVector a, float b)
    {
        ClaseVector divfloat =new ClaseVector (a.X / b, a.Y / b, a.Z / b);
        return divfloat;
    }

    public static float operator *(ClaseVector a, ClaseVector b)
    {
        float productoescalar =(b.X * a.X + b.Y * a.Y + b.Z * a.Z);
        return productoescalar;
    }

    public static ClaseVector operator ^(ClaseVector a, ClaseVector b)
    {
        ClaseVector productovectorial = new ClaseVector((a.Y * b.Z - a.Z * b.Y), (a.X * b.Z + a.Z * b.X), (a.X * b.Y - a.Y * b.X));
        return productovectorial;
    }

    public override string ToString()
    {
        return "(" +X +", "+Y +", "+Z +")";
    }
    #endregion
    #endregion

    public Vector3 toVector3()
    {
        return new Vector3(X, Y, Z);
    }
}
