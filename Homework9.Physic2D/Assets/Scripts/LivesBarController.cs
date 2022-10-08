using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;


public class LivesBarController : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;
    private int count;
    private int lives;
   
    private void Start()
    {
        lives = 5;
        count = lives;
        GlobalEventManager.OnFruitTaked.AddListener(AddLives);
        GlobalEventManager.OnDamage.AddListener(LoseLives);
        Debug.Log(count);
    }

    private void Update()
    {
        if (count > lives) 
        {
            count = lives;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i<count)
            {
                hearts[i].sprite = aliveHeart;
            }
            else
            {
                hearts[i].sprite = deadHeart;
            }

            if (i<lives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void AddLives(bool isAdd)
    {
        if (isAdd && count < 5)
        {
            count += 1;
            Debug.Log(count);
        }
    }

    private void LoseLives(int demage)
    {
        count -= demage;
       
        if (count<=0)
        {
            GlobalEventManager.SendDead(true);
            count = 5;
        }
    }
}
