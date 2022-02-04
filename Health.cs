using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int numOfHearts;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void GetDamage() // metoda, ktora sprawi, że bedziemy mogli otrzymac obrazenia od npc
    {
        health--;
    }


    void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.playerDied = true;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > numOfHearts)
            {
                health = numOfHearts;
            }

            if (i < health) // sprawdzamy tutaj, czy dana iteracja jest mniejsza od zycia, 
                //jezeli tak - oznacza to, ze napewno gracz ma na danej iteracji pelne serce,
                //na reszcie natomiast bedzie to serce puste
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else 
            {
                hearts[i].enabled = false;
            }
        }
    }
}
