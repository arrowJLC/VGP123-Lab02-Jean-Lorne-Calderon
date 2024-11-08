using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] CoinPreferb, JumpBoostPreferb, LifePreferb;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (powerSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        IEnumerable powerSpawn()
        {
            for (int i = 0; i < 5; i++)
            {

            }
        }
    }
}
