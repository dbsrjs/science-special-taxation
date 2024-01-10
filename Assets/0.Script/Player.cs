using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;   //gameOver �޽���
    [SerializeField] private GameObject restart_buttin; //����� ��ư
    [SerializeField] private Animator animator;

    private Score score;

    private bool jump = true;
    private Quaternion initialRotation;

    void Start()
    {
        score = FindObjectOfType<Score>();
        initialRotation = transform.rotation;
    }


    void Update()
    {
        transform.rotation = initialRotation;

        if (Time.timeScale != 0 && jump == true)
        {
            animator.SetTrigger("doRun");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Debug.Log("test");
            jump = true;
        }
        
        else if (score != null)
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
    }

    public void Restart_Btn()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
