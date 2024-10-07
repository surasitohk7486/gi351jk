using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleNumber : MonoBehaviour
{
    public GameObject puzzlePanel;
    
    public TextMeshProUGUI[] numberSlots;
    private int[] currentCode = { 0, 0, 0, 0 };
    private int[] correctCode = { 0, 9, 1, 0 };
    private int activeSlot = 0;
    
    private void Start()
    {
        puzzlePanel.SetActive(false);
        UpdateNumberSlots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !puzzlePanel.activeSelf)
        {
            OpenPuzzle();
        }

        if (puzzlePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePuzzle();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                TryUnlock();
            }

            // Change number in the active slot
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ChangeNumber(1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ChangeNumber(-1);
            }
        }
    }

    private void OpenPuzzle()
    {
        puzzlePanel.SetActive(true);
        
        ChangeLighting(0.5f); // Reduce game light
    }

    private void ClosePuzzle()
    {
        puzzlePanel.SetActive(false);
        
        ChangeLighting(1f); // Restore game light
    }

    private void ChangeLighting(float alpha)
    {
        // Implement lighting changes here, e.g., reducing brightness
    }

    private void ChangeNumber(int change)
    {
        currentCode[activeSlot] = (currentCode[activeSlot] + change + 10) % 10;
        UpdateNumberSlots();
    }
    private void UpdateNumberSlots()
    {
        for (int i = 0; i < numberSlots.Length; i++)
        {
            numberSlots[i].text = currentCode[i].ToString();
        }
    }

    private void TryUnlock()
    {
        if (IsCorrectCode())
        {
            Unlock();
        }
        else
        {
            // Play wrong sound
            Debug.Log("Wrong Code!");
        }
    }

    private bool IsCorrectCode()
    {
        for (int i = 0; i < correctCode.Length; i++)
        {
            if (currentCode[i] != correctCode[i])
            {
                return false;
            }
        }
        return true;
    }

    private void Unlock()
    {
        // Play success sound
        Debug.Log("Unlocked!");
        ClosePuzzle();
    }
}
