using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MYXA : MonoBehaviour
{
    static public bool ti_ymer;
    private GameObject killHim;
    public float aggroDistance;
    public float distance;
    public float speed;
    public Animator anim;
    private void Start()
    {
        killHim = GameObject.Find("Player");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !PlayerControl.roll)
        {
            ti_ymer = true;
            anim.SetBool("deathAnim", true);
        }
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, killHim.transform.position);
        if (distance <= aggroDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, killHim.transform.position, speed * Time.deltaTime);
        }
        if (transform.position.y > 50)
        {
            Destroy(gameObject);
        }
    }
}
