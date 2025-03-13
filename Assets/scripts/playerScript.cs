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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agente.SetDestination(hit.point);
            }
        }
        if (posicionObjeto != null) { 
            agente.SetDestination(objetivos[(int)posicionObjeto].position);
        }

    }

}
