using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        Contexts.sharedInstance.game.score.value.SubscribeToText(_text);
    }
}
