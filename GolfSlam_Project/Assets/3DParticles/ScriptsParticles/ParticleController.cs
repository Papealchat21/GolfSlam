using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleController : MonoBehaviour
{
    public Particle partVar;
    public GameObject particula;
    public Transform tank;
    public Transform spawn;
    public Transform cannon;
    public List<GameObject> particlecontroller = new List<GameObject>();
    public int maxparticles;
    public Slider sliderFuerza;
    public Slider sliderInclinación;
    public Text intentosText;

    public bool permitir;
    public Text canonReady;
    public int intentos;

    //Variables de cada particula;
    public float maxTime;
    public float activeTime;
    public float gravity;

    float randomGravityX;
    float randomGravityZ;

    //FLECHA
    public Transform flechafuerza;
    public Transform flechaaltura;
    public Transform flechaaire;


    #region practica1
    //Variables practica fisica
    [SerializeField]private float Alpha;
    [SerializeField]private float Gamma;
    private float tamanyCanon;//sera molt xicotet per a simular el tirar la bola.
    private float alturaCanon;

    [SerializeField]private float Velocidad;

    public float VelocidadX;
    public float VelocidadY;
    public float VelocidadZ;

    public float proyeccionCañon;
    public float proyeccionCañonX;
    public float proyeccionCañonY;
    public float proyeccionCañonZ;

    public float Ox;
    public float Oy;
    public float Oz;
    #endregion

    //variables nuevas
    public float Cd ;   //constante para el medio en el que se propaga.
    public float Cw ;     //constante para el medio en el que se propaga.
    public float Vw ;     //velocidad del viento
    public float Yw;      //angulo en el que actúa el viento
    public float M;    // masa del objeto qeu lanzamos, pelota de golf

    private Vector3 tranformPosition;
    public Quaternion canonObject;

    // Start is called before the first frame update
    void Start()
    {

        canonReady.GetComponent<Text>().text = "DISPARO LISTO";
        permitir = true;
        cannon = GetComponent<Transform>(); 
        Velocidad = 1f;
        tamanyCanon = 2f;
        alturaCanon = 25f;
        Cd = 1;
        Cw = 1;
        Vw = Random.Range(-35, -10);
        M = 5;
        Yw = Random.Range(-75, 75);

        //canonObject.localScale = new Vector3(1, tamanyCanon*2.5f, 1);
        intentos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        flechafuerza.localScale = new Vector3(0.03530219f, 0.01003036f, Velocidad * .06f);
        flechaaire.eulerAngles = new Vector3(0, Yw-180, -90);
        flechaaltura.eulerAngles = new Vector3(Alpha+90, Gamma, 0f);
        Velocidad = sliderFuerza.value;
        Alpha = sliderInclinación.value;
        Gamma = tank.transform.rotation.eulerAngles.y;
        if (Input.GetKeyDown("space") && particlecontroller.Count != 1)
        {
            tranformPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Debug.Log("BOOOOOM");
            CreateParticles(maxparticles);
            canonReady.GetComponent<Text>().text = "CARGANDO DISPARO";
            intentos++;
            //StartCoroutine("PermitirDisparo");
        }
        else if(particlecontroller.Count == 0)
        {
            canonReady.GetComponent<Text>().text = "DISPARO LISTO";
        }
        intentosText.GetComponent<Text>().text = "" +intentos;
    }


    void CreateParticles(int maxparticles)
    {
        for(int i = 0; i < maxparticles; i++)
        {
            GameObject copy = Instantiate(particula, spawn.position, Quaternion.identity);
            partVar.activetime = 0;
            partVar.gravity = gravity;           
            copy.GetComponent<Particle>().maxTime = Random.Range(maxTime / 2, maxTime);
            particlecontroller.Add(copy);
        }
    }

    void FixedUpdate()
    {
        for(int i = 0; i < particlecontroller.Count; i++)
        {
            try
            {
                ClaseVector direccion = DoSimulator(particlecontroller[i].GetComponent<Particle>(), Time.deltaTime);
                if (particlecontroller[i].GetComponent<Particle>().activetime >= particlecontroller[i].GetComponent<Particle>().maxTime)
                {
                    GameObject toDestroy = particlecontroller[i];
                    particlecontroller.RemoveAt(i);
                    Destroy(toDestroy);
                }
                else
                {
                    for (int j = 0; j < particlecontroller.Count; j++)
                    {
                        particlecontroller[i].transform.position = direccion.toVector3();
                    }
                }
            }
            catch
            {
                particlecontroller.RemoveAt(i);
            }
        }
    }

    ClaseVector DoSimulator(Particle partVar, float activeTime)
    {
        partVar.activetime += activeTime;
        ClaseVector direccion = new ClaseVector();
        
        //Paso 1 (Calcular la proyeccion del cañon):
        proyeccionCañon =  Mathf.Cos((90 - Alpha) * Mathf.PI / 180);

        //Paso 2 (Calcular la proyeccion del cañon en X, Y y Z):
        proyeccionCañonX = Mathf.Cos((90 - Alpha) * Mathf.PI / 180) * Mathf.Sin(Gamma * Mathf.PI/180);
        proyeccionCañonY = Mathf.Cos(Alpha * Mathf.PI / 180);
        proyeccionCañonZ = Mathf.Cos((90 - Alpha) * Mathf.PI / 180) * Mathf.Cos(Gamma * Mathf.PI / 180);

        //Paso 3 (Calcular el angulo O):
        Ox = proyeccionCañonX;
        Oy = proyeccionCañonY;
        Oz = proyeccionCañonZ;

        //Paso 4 (Calcular los valores de la velocidad):
        VelocidadX = Velocidad * Ox;
        VelocidadY = Velocidad * Oy;
        VelocidadZ = Velocidad * Oz;

        //Paso 5 (Usar los datos extraidos para calcular las formulas en funcion del tiempo):
        direccion.Z = transform.position.z+ (M / Cd * Mathf.Exp(-Cd * partVar.activetime / M) * (-Cw * Vw * Mathf.Cos(Yw * Mathf.PI / 180) / Cd - VelocidadZ) - Cw * Vw * Mathf.Cos(Yw * Mathf.PI / 180) / Cd * partVar.activetime) - (M / Cd * (-Cw * Vw * Mathf.Cos(Yw * Mathf.PI / 180) / Cd - VelocidadZ));
        direccion.Y = transform.position.y + (-(VelocidadY + M * gravity / Cd) * M / Cd * Mathf.Exp(-Cd * partVar.activetime / M) - M * gravity / Cd * partVar.activetime) + (M / Cd * (M * gravity / Cd + VelocidadY));
        direccion.X = transform.position.x + (M / Cd * Mathf.Exp(-Cd * partVar.activetime / M) * (-Cw * Vw * Mathf.Sin(Yw * Mathf.PI / 180) / Cd - VelocidadX) - Cw * Vw * Mathf.Sin(Yw * Mathf.PI / 180) / Cd * partVar.activetime) - (M / Cd * (-Cw * Vw * Mathf.Sin(Yw * Mathf.PI / 180) / Cd - VelocidadX));



        return direccion;

    }

}
