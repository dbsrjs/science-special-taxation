using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : GameManager
{
    [SerializeField] private Text score_text;
    [SerializeField] private Text max_score_text;

    [HideInInspector] public float nomal_score = 0;
    [HideInInspector] public float question_score = 0;
    private float max_score = 0;

    [SerializeField] private GameObject panel;
    [SerializeField] private Text question_Text;    //���� ���
    [SerializeField] private List<string> questions; // ���� ����Ʈ

    int randomIndex;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    void Update()
    {
        if (timeSize != 0)
        {
            nomal_score += Time.deltaTime * 13;   //nomal_score �� ����(13)
            question_score += Time.deltaTime * 13;
            score_text.text = Mathf.FloorToInt(nomal_score).ToString("0000");   //Mathf.FloorToInt : ������ ǥ��
        }
    }

    public void Die()
    {
        if (nomal_score > max_score)
        {
            max_score = nomal_score;//max_score �� ����
            max_score_text.text = Mathf.FloorToInt(max_score).ToString("0000");
            nomal_score = 0;    //���� �ʱ�ȭ
            question_score = 0;
        }
    }

    public void Question() //���� ���
    {
        panel.SetActive(true);
        GameStop();
        randomIndex = Random.Range(0, questions.Count); //14���� ����
        string randomQuestion = questions[randomIndex];
        question_Text.text = randomQuestion;        
        //Debug.Log(randomIndex);
    }

    public void O_Button()
    {
        if (randomIndex <= 14)
        {
            panel.SetActive(false);
        }
        else
        {
            nomal_score -= 30;
            panel.SetActive(false);
        }
        GameStart();
    }

    public void X_Button()
    {
        if (randomIndex < 14)
        {
            nomal_score -= 30;
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(false);
        }
        GameStart();
    }
}
