using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    bool moveAllowed;
    Collider2D col;
    private GameController gc;
    void Start()
    {
        col = GetComponent<Collider2D>();
        gc = GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began){
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchCollider){ 
                    moveAllowed = true;
                }
            }
            if(touch.phase == TouchPhase.Moved){
                if(moveAllowed){
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if(touch.phase == TouchPhase.Ended){
                moveAllowed = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Ball"){         
            gc.ShowGameOver();
            Destroy(gameObject);
        }
    }
}
