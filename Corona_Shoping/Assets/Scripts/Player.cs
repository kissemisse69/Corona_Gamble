using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    int day;
    int hp = 10;
    int food;

    int coronaItems;

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        
    }

    public int GetHP() { return hp; }
    public int GetFood() { return food; }
    public int GetDay() { return day; }

    public void AddFood(int addedFood) { food = addedFood; }

    public int GetCoronaItems() { return coronaItems; }
    public void SetCoronaItems(int addedCoronaItems) { coronaItems = addedCoronaItems; }
    public void SetDay(int _day) { day = _day; }
    public void SetHP(int newHP) { hp = newHP; }
}
