using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    [Header("水平方")]
    public float moveX;

    [Header("垂直方")]
    public float moveY;

    [Header("推力")]
    public float push = 6;

    //刚体，以便施加推力
    Rigidbody2D rb2D;

    [Header("分数")]
    public Text countText;

    [Header("结束")]
    public Text winText;

    int score;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();

        winText.text = "";
        setScoreText();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb2D.AddForce(push * movement);
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(name + "出发了" + other.name);
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            setScoreText();
        }
    }

    void setScoreText()
    {
        countText.text = "分数：" + score.ToString();
        if (score >= 12)
        {
            winText.text = "GAME OVER";
        }
    }
}
