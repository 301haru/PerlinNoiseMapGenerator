using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;//ΩÃ±€≈Ê
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("GameManager").AddComponent<GameManager>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set

        {
            instance = value;
        }
    }//ΩÃ±€≈Ê
    private void Awake()
    {
        var objs = FindObjectsOfType<GameManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Movement(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            t.transform.Translate(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            t.transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            t.transform.Translate(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            t.transform.Translate(Vector3.down);
        }
    }
}
