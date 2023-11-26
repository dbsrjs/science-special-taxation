using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;   //gameOver �޽���
    [SerializeField] private GameObject restart_buttin; //����� ��ư

    [SerializeField] private Animator animator;

    private Score score;
    private GameManager gameManager;

    void Start()
    {
        score = FindObjectOfType<Score>();
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if (gameManager.timeSize == 1)
        {
            animator.SetTrigger("doRun");
            if (Input.GetKeyDown(KeyCode.Space))    //����
            {
                if (transform.position.y <= 0.017)
                {
                    animator.SetTrigger("doJump");
                    Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
                    rigidbody.AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
                }
            }

            if (score.question_score >= 50 && transform.position.y <= 0.017)
            {
                score.Question();
                score.question_score = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (score != null)
        {
            if (collision.gameObject.layer == 6)    //������� �浹
            {
                animator.SetTrigger("doDie");
                score.Die();  //max_score �� ����
                gameManager.GameStop(); //���� ����
                gameOver.SetActive(true);
                restart_buttin.SetActive(true);
            }
        }
    }
    
    public void Restart_Btn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        gameManager.GameStart(); //���� ����
    }
}
