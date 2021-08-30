using UnityEngine;
using UniRx;

public class ScoreContainer : MonoBehaviour
{
    public int score;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        score = 0;
    }

    private void Start()
    {
        Contexts.sharedInstance.game.score.value.Subscribe(score => this.score = score);
    }
}
