using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class product : MonoBehaviour {

    [SerializeField]
    bool corona;

    public bool selected;

    void Start() {
        if(Random.Range(0, 4) == 0) corona = true;
        else corona = false;
    }

    void Update() {
        if(selected) {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if(Input.GetMouseButtonUp(0)) {
            selected = false;
        }
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)) {
            selected = true;
        }
    }

    public bool GetItemCorona() {
        return corona;
    }
}
