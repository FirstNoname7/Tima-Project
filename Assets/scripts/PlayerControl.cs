using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Collider2D colliderMYXA;
    public float rDelayTime;
    static public bool roll;
    public float rollForce;
    public Animator anim;
    public Animator animCamera;
    public bool tochGround;
    public float move;
    public float speed;
    public float vInput;
    public float jumpForce;
    Rigidbody2D jump;
    public float testRL; 
    void Start()
    {
        jump = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            tochGround = true;
        }
    }
    IEnumerator rDelay()
    {
        roll = true;
        colliderMYXA.isTrigger = true;
        jump.AddForce(Vector2.right * rollForce);
        yield return new WaitForSeconds(rDelayTime);
        roll = false;
        colliderMYXA.isTrigger = false;
        yield return new WaitForSeconds(rDelayTime);
    }
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * move * Time.deltaTime * speed);
        if (move > 0 || move < 0)
        {
            transform.localScale = new Vector2(move, 1);
        }
        anim.SetBool("jumpAnim", false);
        //if (MYXA.ti_ymer)
        //{
        //    animCamera.SetBool("deathAnim", true);
        //}
        if (tochGround && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jumpAnim", true);
            jump.AddForce(Vector2.up * jumpForce);
            tochGround = false;
        }
        if (Input.GetMouseButtonDown(1) && !roll)
        {
            StartCoroutine(rDelay());
        }
    }
}