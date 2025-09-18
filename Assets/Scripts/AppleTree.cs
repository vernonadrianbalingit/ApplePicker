using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]  //header is for fields that will not change while the game is running
    // Start is called before the first frame update

    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    //chance that the apple tree will change directions
    public float chanceDirChance = 0.1f;

    //Seconds betwen apple instantiantions
    public float appleDropDelay = 1f;


    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position; //set position of apple to apple tree and not prefab
        Invoke("DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        // Changing Directions
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        } else if (pos.x > leftAndRightEdge ){
            speed = -Mathf.Abs(speed); //Move left
        } 
    }

    void FixedUpdate()
    {
        //Random direction changes are now time-based due to Fixedpdate()
        if (Random.value < chanceDirChance)
        {
            speed *= -1; //change directions
        }
    }
}
