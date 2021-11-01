using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;//ΩÃ±€≈Ê
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<PlayerManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("PlayerManager").AddComponent<PlayerManager>();
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
        var objs = FindObjectsOfType<PlayerManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }


    [SerializeField] private Transform player;


    public (int x, int y) getPlayerPositionXY()
    {
        return ((int)player.position.x, (int)player.position.y);
    }
}
