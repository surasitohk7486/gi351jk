using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบว่าผู้เล่นเป็นคนมาชน
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with Princess"); // ใช้ Debug เพื่อตรวจสอบการชน
            SceneManager.LoadScene("End");
        }
    }

}
