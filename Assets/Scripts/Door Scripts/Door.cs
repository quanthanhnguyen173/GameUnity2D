using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public static Door instance;

    private Animator anim;
    private BoxCollider2D box;

    [HideInInspector]
    public int collectablesCount;

    public static int Scene;


    void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DecrementCollectables()
    {
        collectablesCount--;

        if (collectablesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }     
    }


    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Scene = Random.Range(1, 21);
            GameplayController.level++;
            SoundController.PlaySound(soundsGame.win);       
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().LoadNextLevel(Scene);
            //GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
            //Debug.Log("Finish");
        }
    }

    // Use this for initialization
    void Start () {
        collectablesCount = 10;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
