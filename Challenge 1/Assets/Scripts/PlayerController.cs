using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text livesText;
    public Text scoreText;
    public Text winText;
    public Text loseText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetAllText();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetAllText();;

            if (score == 12) 
            {
                transform.position = new Vector3(-64.54f, transform.position.y, -0.33f); 
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);

            if (lives > 0 && loseText.text != "You Lose!" && winText.text != "You Win!")
            {
                count = count + 1;
                lives = lives - 1;
            }
            SetAllText();
        }
    }

    void SetAllText()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();

        if (lives > 0)
        {
            if (score >= 24 && loseText.text != "You Lose!" && lives > 0)
            {
                winText.text = "You Win!";
            }
        }
        else if (lives == 0)
        {
            Destroy(gameObject);
            loseText.text = "You Lose!";
        }
    }
}