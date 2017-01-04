using UnityEngine;
using System.Collections;

public class TimeAndAir : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (gameObject.name == "Air")
            {
                SoundController.PlaySound(soundsGame.air);
                GameObject.Find("Gameplay Controller").GetComponent<AirTimer>().air += Random.Range(1f,6f);
            }
            else
            {
                SoundController.PlaySound(soundsGame.time);
                GameObject.Find("Gameplay Controller").GetComponent<LevelTimer>().timer += Random.Range(1f, 6f);
            }
            Destroy(gameObject);
        }

    }

}
