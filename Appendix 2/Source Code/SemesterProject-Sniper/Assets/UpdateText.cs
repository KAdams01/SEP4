using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    private Text txt;
    private ScoreManager scoreMan;
    private float lastScoreChecked;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        scoreMan = ScoreManager.Instance;
        lastScoreChecked = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckScore());
    }
    IEnumerator CheckScore()
    {
        while (true)
        {
            if (scoreMan.mainScore != lastScoreChecked)
            {
                txt.text = " " + scoreMan.mainScore;
            }
            lastScoreChecked = scoreMan.mainScore;
            yield return new WaitForSeconds(1);
        }
    }
}
