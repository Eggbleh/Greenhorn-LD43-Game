using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float range;
    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player_1").GetComponent<Transform>();
		//Makes the enemy find the player object
	}

    // Update is called once per frame
    void Update()
    {

        

            if (Vector2.Distance(transform.position, target.position) < range)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
                
        
    }
}
