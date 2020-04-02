using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{

    [SerializeField]
    GameObject[] products;

    GameObject basket;

    Text doneText;
    
    void Start() {

        basket = GameObject.FindGameObjectWithTag("Basket");
        doneText = GameObject.Find("UI").transform.Find("FinalText").GetComponent<Text>();

        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");
        for(int i = 0; i < spawns.Length; i++) {
            GameObject newItem = Instantiate(products[Random.Range(0, products.Length)], spawns[i].transform);
        }
    }

    public void Done() {
        List<GameObject> items = basket.GetComponent<Basket>().GetBasketItems();
        int coronaItems = 0;
        for(int i = 0; i < items.Count; i++) {
            if(items[i].GetComponent<product>().GetItemCorona()) {
                coronaItems++;
            }
        }

        doneText.text = "You bought " + coronaItems.ToString() + " items with corona on them!";
    }
}
