using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour
{

    private GameObject enemigo;
    private bool esta_activa;
    private float distancia_umbral;
    private float tiempo_disparo;
    private GameObject[] balas;
    private int valor_nivel_actual;

    public Torre()
    {
        Valor_nivel_actual = 300;
    }

    // Use this for initialization
    void Start()
    {
        distancia_umbral = 2f;
        tiempo_disparo = .8f;
        CrearBalas(5);
    }

    // Update is called once per frame
    void Update()
    {

        Enemigo = BuscarEnemigoCercano();
        if (Enemigo != null && tiempo_disparo <= 0)
        {
            Disparar();
            Debug.DrawLine(this.transform.position, enemigo.transform.position, Color.yellow);
            tiempo_disparo = 1f;
        }
        else
        {
            tiempo_disparo -= Time.deltaTime;
        }

    }

    private void CrearBalas(int total_balas)
    {
        balas = new GameObject[total_balas];
        for (int i = 0; i < balas.Length; i++)
        {
            balas[i] = Instantiate(GameObject.Find("bala"), this.transform.position, Quaternion.identity);
        }
    }

    private Bala DespacharBalaLibre()
    {
        Bala libre = null;

        for (int i = 0; i < balas.Length; i++)
        {
            libre = balas[i].GetComponent<Bala>();

            if (!libre.Disparada)
            {
                break;
            }
        }
        return libre;
    }

    void Disparar()
    {
        Bala bala = DespacharBalaLibre();
        bala.ActivarBala(this);
    }

    GameObject BuscarEnemigoCercano()
    {
        ArrayList enemigos = PoolingUnidades.unidades;
        GameObject temp;
        foreach (Object item in enemigos)
        {
            temp = (GameObject)item;
            if (Vector3.Distance(temp.transform.position, this.transform.position) < distancia_umbral)
            {
                if (temp.GetComponent<Unidad>().Esta_viva)
                {
                    return temp;
                }
            }
        }
        return null;
    }

    public bool Esta_activa
    {
        get
        {
            return esta_activa;
        }

        set
        {
            esta_activa = value;
        }
    }

    public GameObject Enemigo
    {
        get
        {
            return enemigo;
        }

        set
        {
            enemigo = value;
        }
    }

    public int Valor_nivel_actual
    {
        get
        {
            return valor_nivel_actual;
        }

        set
        {
            valor_nivel_actual = value;
        }
    }

    public ControlesTorre ControlesTorre
    {
        get => default;
        set
        {
        }
    }
}