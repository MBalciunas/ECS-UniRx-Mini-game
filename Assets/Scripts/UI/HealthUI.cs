using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Sprite lifeEmptySprite;
    public Sprite lifeFullSprite;
    private int maxHp;

    void Start()
    {
        maxHp = Contexts.sharedInstance.game.playerEntity.health.value.Value;
        UpdateHealthUI(maxHp);

        Contexts.sharedInstance.game.playerEntity.health.value.Subscribe(hp => { UpdateHealthUI(hp); });
    }

    private void UpdateHealthUI(int hp)
    {
        for (int i = 0; i < hp; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = lifeFullSprite;
        }
        
        for (int i = hp; i < maxHp; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = lifeEmptySprite;
        }
    }
}