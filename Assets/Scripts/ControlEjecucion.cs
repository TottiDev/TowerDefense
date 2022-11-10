using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlEjecucion : MonoBehaviour,IPointerClickHandler
{
    private bool habilitado;

    public PoolingUnidades PoolingUnidades
    {
        get => default;
        set
        {
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hud hud;
        hud = Hud.GetInstance();
        if (habilitado)
        {
            hud.Modo_ejecucion = Hud.EJECUCION;
            habilitado = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        habilitado = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
