using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private void Awake()
    {
        var scoreContainer = GameObject.FindWithTag("Score").gameObject;
        var highscore = scoreContainer.GetComponent<ScoreContainer>().score.ToString();
        var text = GetComponent<Text>();
        text.text += highscore;
        Destroy(scoreContainer);
    }
}
