using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // ��Ǩ�ͺ��Ҽ������繤��Ҫ�
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with Princess"); // �� Debug ���͵�Ǩ�ͺ��ê�
            SceneManager.LoadScene("End");
        }
    }

}
