using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class scriptItem : MonoBehaviour
{
   
    [SerializeField]public ItemSO itemData;
    private float yPosition;
    private bool finalPosition=false;

    public float amplitude = 0.1f; // Altura máxima de levitación
    public float frequency = 0.1f;   // Velocidad de oscilación

    private Vector3 startPos;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0));
        yPosition = transform.position.y;
    }

    private void Update()
    {
        Debug.Log(transform.position.y);
        if (yPosition + 0.5 < transform.position.y && !finalPosition)
        {
            startPos = transform.position;

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            finalPosition = true;
        }
        else if(finalPosition) {
            float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;
            transform.position = startPos + new Vector3(0, offsetY-0.5f, 0);
        }
    }   
    public string ToString() { 
        return itemData.ToString();
    }
  

}
