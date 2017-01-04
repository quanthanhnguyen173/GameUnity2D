using UnityEngine;
using System.Collections;

public class SpiderBullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            GameplayController.player--;
            SoundController.PlaySound(soundsGame.touch);
            if (GameplayController.player == 0)
            {
                SoundController.PlaySound(soundsGame.stop_audio);
                SoundController.PlaySound(soundsGame.fail);
                GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
                Destroy(target.gameObject);
                Destroy(gameObject);
            }
        }

        if (target.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
