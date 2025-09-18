using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public GameObject catchEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Find a GameObjectN named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        //get the score Countyer Script component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        //change the point from 2d screen space into 3 d game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x pos of thie baset to the x pos to the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit the basket
        GameObject collideWith = coll.gameObject;

        if(collideWith.CompareTag("Apple"))
        {
            Vector3 applePosition = collideWith.transform.position;

            // Create particle effect
            if (catchEffectPrefab != null)
            {
                GameObject effect = Instantiate(catchEffectPrefab, applePosition, Quaternion.identity);
                Debug.Log("Particle effect created at: " + applePosition);
                Destroy(effect, 2f);
            }
            else
            {
                Debug.Log("catchEffectPrefab is null!");
            }

            Destroy(collideWith);
            

            //increase the score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
