using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercicoVectores : MonoBehaviour
{
    ClaseVector VectorV = new ClaseVector(2, 4, 5);
    ClaseVector VectorW = new ClaseVector(-2, 3, 4);
    ClaseVector VectorZ = new ClaseVector(3, 3, 7);
    float floatejercicio = 3f;

    // Start is called before the first frame update
    void Start()
    {
        ClaseVector sumavector = VectorV + VectorW;
        Debug.Log(sumavector.ToString());

        ClaseVector restavector = VectorW - VectorV;
        Debug.Log(restavector.ToString());

        ClaseVector multvector = VectorZ * floatejercicio;
        Debug.Log(multvector.ToString());

        ClaseVector divvector = VectorV / floatejercicio;
        Debug.Log(divvector.ToString());

        float escalarvector = VectorV * VectorZ;
        Debug.Log(escalarvector.ToString());

        ClaseVector vectorialvector = VectorW ^ VectorZ;
        Debug.Log(vectorialvector.ToString());

        ClaseVector vectorialvector2 = VectorZ ^ VectorW;
        Debug.Log(vectorialvector2.ToString());

        float escalarvectorial = VectorZ * (VectorW ^ VectorV);
        Debug.Log(escalarvectorial.ToString());
    }

}
