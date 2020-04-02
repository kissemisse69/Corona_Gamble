using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

    public List<GameObject> items = new List<GameObject>();

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Product") {
            for(int i = 0; i < items.Count; i++) {
                if(items[i] == collision.gameObject) return; }
            items.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Product") {
            for(int i = 0; i < items.Count; i++) {
                if(items[i] == collision.gameObject) items.Remove(items[i]);
            }
        }
    }

    public List<GameObject> GetBasketItems() {
        return items;
    }
}
