using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPonerTorre : MonoBehaviour
{
    [SerializeField]
    private GameObject go_torre;
    private Hud hud;
    private Torre torre;

    public Torre Torre
    {
        get => default;
        set
        {
        }
    }

    public Torre Torre1
    {
        get => default;
        set
        {
        }
    }

    void OnMouseDown()
    {
        GameObject temp;
        Vector3 pos = this.transform.position;
        pos.y = pos.y + 0.3f;
        temp = (GameObject)Instantiate(go_torre, pos, Quaternion.identity);
        temp.transform.position = pos;
        temp.layer = 7;
        hud = Hud.GetInstance();
        torre = temp.GetComponent<Torre>();

        if (torre.Valor_nivel_actual <= hud.Contador_monedas)
        {
            torre.Esta_activa = true;
            Destroy(this.gameObject);
            hud.DescontarSaldo(torre.Valor_nivel_actual);
        }
        else
        {
            Destroy(temp);
            hud.ErrorSaldoInsuficiente();
        }

               
    }
}
