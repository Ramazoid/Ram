using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject scoreblock;
    public GameObject coin;
    public Text scoretext;
    public int score = 0;
    public float InitialItemSpeed = 0.01f;
    public float TapIncreaseSpeed;
    public static float ItemSpeed;
    public int tapcount;
    private Vector3 coinpos;
    private bool movecoin=false;
    private Vector3 coinScale;
    private int animTextPhase=0;
    private Vector3 scoreScale;

    void Start()
    {
    scoreblock.SetActive(false);
        coin.SetActive(false);
    ItemSpeed = InitialItemSpeed;
        coinpos = coin.transform.position;
        coinScale = coin.transform.localScale;
        scoreScale = scoretext.transform.localScale;
        scoretext.text = score.ToString() + " Coins";


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ItemSpeed += TapIncreaseSpeed;
            tapcount += 1;

        }

        if (movecoin)
            MoveCoin();
        if(animTextPhase!=0)
            AnimateText();

    }

    private void AnimateText()
    {
        switch (animTextPhase)
        {
            case 1:
                scoretext.transform.localScale = Vector3.one * 1.5f;
                animTextPhase = 2;
                break;
            case 2:
                score += tapcount;
                scoretext.text = score.ToString() + " Coins";
                animTextPhase = 4;
                break;
            
            case 3:
                //ResetTaps();
                animTextPhase = 4;
                break;
            
            case 4:
                scoretext.transform.localScale = scoreScale;
                animTextPhase = 0;
                ResetTaps();
                break;
            
               
        }
    }

    private void MoveCoin()
    {
        coin.transform.position = Vector3.Lerp(coin.transform.position, coinpos, 0.1f);
        coin.transform.localScale = Vector3.Lerp(coin.transform.localScale, coinScale, 0.1f);
        if (Vector3.Distance(coin.transform.position, coinpos) <= 0.01f)
        {
            movecoin = false;
            animTextPhase = 1;
        }
    }

    public void ResetTaps()
    {

        ItemSpeed = InitialItemSpeed;
        tapcount = 1;
    }

    public void EarnCoins()
    {
        scoreblock.SetActive(true);
        coin.SetActive(true);
        coin.transform.position= transform.position;
        coin.transform.localScale = Vector3.one * 2;
        movecoin = true;
    }
}
