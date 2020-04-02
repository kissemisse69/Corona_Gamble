using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NightMaster : MonoBehaviour {

    int day = 1;
    int hp;
    int food;
    int corona;

    Text dayText;
    Text lifeText;
    Text foodText;
    Text coronaText;
    GameObject bShopping;

    void Start() {
        GameObject player = GameObject.Find("Player");
        day = player.GetComponent<Player>().GetDay();
        hp = player.GetComponent<Player>().GetHP();
        food = player.GetComponent<Player>().GetFood();
        corona = player.GetComponent<Player>().GetCoronaItems();

        dayText = GameObject.Find("Night UI").transform.Find("Day Text").GetComponent<Text>();
        lifeText = GameObject.Find("Night UI").transform.Find("Life Text").GetComponent<Text>();
        foodText = GameObject.Find("Night UI").transform.Find("Food Text").GetComponent<Text>();
        coronaText = GameObject.Find("Night UI").transform.Find("Corona Text").GetComponent<Text>();
        bShopping = GameObject.Find("Go Shopping");

        bShopping.SetActive(false);
        dayText.enabled = false;
        lifeText.enabled = false;
        foodText.enabled = false;
        coronaText.enabled = true;

        hp -= corona;
        player.GetComponent<Player>().SetHP(hp);
        coronaText.text = corona + " items had corona on them.. \nYou lost " + corona + " HP";
        

        if(hp <= corona) {
            StartCoroutine("GameOver");
        } else {
            StartCoroutine("Continue");
        }


        dayText.text = "Day " + day;
        lifeText.text = "HP: " + hp;
        foodText.text = "You have food for " + food + " days";
    }

    IEnumerator Continue() {
        yield return new WaitForSeconds(4f);

        dayText.enabled = true;
        lifeText.enabled = true;
        foodText.enabled = true;
        coronaText.enabled = false;

        int x = food+1;
        for(int i = 0; i < x; i++) {
            yield return new WaitForSeconds(1f);
            dayText.text = "Day " + day;
            ++day;
            foodText.text = "You have food for " + food + " days";
            --food;
        }
        foodText.text = "You have no food left!";

        lifeText.enabled = false;
        bShopping.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().SetDay(day);
    }

    IEnumerator GameOver() {
        yield return new WaitForSeconds(4f);
        coronaText.text = "You Died Of Corona!\nYou survied for " + day + " days";
    }

    public void ChangeScene() { SceneManager.LoadScene(0); }
}
