using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class itemChest : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] items;
    private List<scriptItem> itemData;
    private SphereCollider sphereCollider;
    private bool canOpen = false;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        itemData = new List<scriptItem>();
        for (int i = 0; i < items.Length; i++) {
            itemData.Add(items[i].GetComponent<scriptItem>());
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Chest")) // Asegúrate de poner la etiqueta en el objeto
                    {

                        Instantiate(RandomItem(), new Vector3(transform.position.x,transform.position.y+1f,transform.position.z), Quaternion.identity);
                       
                        
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el trigger!");
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha salido en el trigger!");
            canOpen = false;
        }
    }
    private GameObject RandomItem() { 
      float rndNum =  4;
        
        foreach (var item in itemData) {
            Debug.Log("numbre rnd " + rndNum + ", item rarety: " + item.itemData.rarity.probability);
            if (rndNum <= item.itemData.rarity.probability)
            {
                return  System.Array.Find(items, obj => obj.name == item.name);

            }
            else { 
                rndNum -= item.itemData.rarity.probability;
            }
        }
        return null;
    }
  


}
