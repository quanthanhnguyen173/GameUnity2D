using UnityEngine;
using System.Collections;

public class DiamondScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //if (Door.instance != null)
        //{
        //    Door.instance.collectablesCount++;
        //}
    }

    //Xet va cham
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            SoundController.PlaySound(soundsGame.kimcuong);
            GameplayController.s_score += Random.Range(100,600);
            Door.instance.DecrementCollectables();
            Destroy(gameObject);
        }

        //if (Door.instance != null)
        //{
        //    Door.instance.DecrementCollectables();
        //}
    }

    // Update is called once per frame
    void Update () {
	
	}
}