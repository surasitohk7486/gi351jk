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
    private bool isPlayerInRange = false; // ตัวแปรสถานะผู้เล่นอยู่ในระยะ

    private void Update()
    {
        // ตรวจสอบการกดปุ่มเมื่อผู้เล่นอยู่ในพื้นที่
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !puzzlePanel.activeSelf)
        {
            OpenPuzzle();
        }

        // ตรวจสอบการปิด Puzzle ด้วยปุ่ม Escape
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
        if (Ans.text == Answer)
        {
            //play sound
            ClosePuzzle();
        }
        else
        {
            Ans.text = "Error";
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
            isPlayerInRange = true; // เมื่อผู้เล่นเข้ามาในระยะ
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false; // เมื่อผู้เล่นออกจากระยะ
        }
    }
}
