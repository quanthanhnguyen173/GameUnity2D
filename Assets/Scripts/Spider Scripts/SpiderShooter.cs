using UnityEngine;
using System.Collections;

public class SpiderShooter : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    // Use this for initialization
    void Start () {
        StartCoroutine(Attack());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));

        //Vi tri vien dan
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }


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
            }
        }
    }

}
