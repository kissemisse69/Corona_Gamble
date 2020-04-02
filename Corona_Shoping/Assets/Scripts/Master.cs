using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{

    [SerializeField]
    GameObject[] products;

    GameObject basket;

    Text doneText;

    GameObject player;
    
    void Start() {

        player = GameObject.Find("Player");

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

        player.GetComponent<Player>().AddFood(items.Count);
        player.GetComponent<Player>().SetCoronaItems(coronaItems);
        doneText.text = "You bought " + items.Count + " items!";
        StartCoroutine("ChangeScene");
    }

    IEnumerator ChangeScene() {
        yield return new WaitForSeconds(2f);
        float timer = 2;
        for(int i = 0; i < timer; i++) {
            yield return null;
            timer += Time.deltaTime;
        }
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
