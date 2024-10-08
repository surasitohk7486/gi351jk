using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleNumber : MonoBehaviour
{
    public GameObject puzzlePanel;
    public GameObject objectToDestroy;

    [SerializeField] private TextMeshProUGUI Ans;

    private string Answer = "0910";

    private void Update()
    {
        if (puzzlePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePuzzle();
            }
        }
    }
    public void Number(int num)
    {
        Ans.text += num.ToString();
    }

    public void Check()
    {
        if(Ans.text == Answer)
        {
            //play sound
            ClosePuzzle();
        }
        else
        {
            Ans.text = "";
            
        }
    }

    private void OpenPuzzle()
    {
        puzzlePanel.SetActive(true);
    }

    private void ClosePuzzle()
    {
        puzzlePanel.SetActive(false);
        objectToDestroy.SetActive(false);
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !puzzlePanel.activeSelf)
            {
                OpenPuzzle();
            }
        }
    }
}
