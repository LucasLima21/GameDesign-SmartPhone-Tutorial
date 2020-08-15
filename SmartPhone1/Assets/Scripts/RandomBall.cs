using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RandomBall : MonoBehaviour
{
    // Start is called before the first frame update
    public float minX, minY, maxX, maxY, minSpeed, maxSpeed, secondsMaxToDifficulty;
    float speed;
    Vector2 targetPosition;
    void Start()
    {
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)transform.position != targetPosition){
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, (speed*Time.deltaTime));
        }
        else{
            targetPosition = GetRandomPosition();
        }
    }

    Vector2 GetRandomPosition(){
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    float GetDifficultPercent(){
        return Mathf.Clamp01(Time.timeSinceLevelLoad/secondsMaxToDifficulty);
    }
}
