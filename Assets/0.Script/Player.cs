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

    void Start()
    {
        score = FindObjectOfType<Score>();
    }


    void Update()
    {
        if (Time.timeScale != 0 && score.panel.activeSelf == false)
        {
            animator.SetTrigger("doRun");
            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 0.017)
            {
                animator.SetTrigger("doJump");
                Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
                rigidbody.AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
            }
        }

        if (score.question_score >= 50 && transform.position.y <= 0.017)    //���� ���
        {
            score.Question();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (score != null)
        {
            if (collision.gameObject.layer == 6)    //������� �浹
            {
                animator.SetTrigger("doDie");
                score.Die();  //max_score �� ����
                Time.timeScale = 0;
                gameOver.SetActive(true);
                restart_buttin.SetActive(true);
            }
        }
        */
    }
    
    public void Restart_Btn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
