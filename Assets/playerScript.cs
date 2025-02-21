using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public Transform[] objetivos;
    public NavMeshAgent agente;
    private int? posicionObjeto = null;
    private Vector3 mousePosition;
    private Vector3 worldPosition;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           posicionObjeto = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            posicionObjeto = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            posicionObjeto = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            posicionObjeto = 3;
        }
        if (Input.GetMouseButtonDown(0)) {
            mousePosition = Input.mousePosition;
            Debug.Log(mousePosition.z.ToString());
            mousePosition.z = 4;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log("mouse: " + mousePosition);
            Debug.Log("posicion: "+worldPosition);
            agente.SetDestination(worldPosition);
        }
        if (posicionObjeto != null) { 
            agente.SetDestination(objetivos[(int)posicionObjeto].position);
        }

    }

}
