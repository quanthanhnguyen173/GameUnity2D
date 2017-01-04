using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {

    public float force = 200f;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator AnimateBouncy()
    {
        anim.Play("Up");
        yield return new WaitForSeconds(.5f);
        anim.Play("Down");
    }

    //Xet va cham
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            target.gameObject.GetComponent<PlayerScript>().BouncePlayerWithBouncy(force);
            StartCoroutine(AnimateBouncy());
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
