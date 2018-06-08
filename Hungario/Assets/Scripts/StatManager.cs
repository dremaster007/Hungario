using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public PlayerAttack playerAttack;

    public float health = 100;
    public float food = 100;
    public float water = 100;
    public float cold = 100;

    public int wood = 10;
    public int rock = 5;
    public int gold;
    public int diamond;

    public Text healthText;
    public Text foodText;
    public Text waterText;
    public Text coldText;
    public Text woodText;
    public Text rockText;
    public Text goldText;
    public Text diamondText;

    public void Update()
    {
        TextChange();
    }

    public void ResourceChange()
    {
        //if(playerAttack.OnTriggerEnter2D()
    }

    public void TextChange()
    {
        foodText.text = ("Food:     " + food);
        woodText.text = ("Wood:     " + wood);
        rockText.text = ("Rock:     " + rock);
        goldText.text = ("Gold:     " + gold);
        diamondText.text = ("Diamond   " + diamond);
    }

}
