using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    //void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonDown(0)) {
    //        Debug.Log("Click");
    //    }
    //}
    // 
    private int counter = 0;
    void OnMouseDown() {
        Debug.Log("Click " + this.name);
        var sprite = GetComponent<SpriteRenderer>();
        //sprite.sortingOrder = counter++;
        sprite.transform.Translate(0, 10, 0);
    }
}
