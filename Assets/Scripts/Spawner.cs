using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject []enemy;
    [SerializeField] float delaySpawn = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(EnemySpawn());
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameStart) return;
    }
    IEnumerator EnemySpawn()
    {
        
        while (true)
        {
            int randomValue = Random.Range(0, enemy.Length);
            int randomxpos = Random.Range(-15, 15);
            GameObject gameObject = Instantiate(enemy[randomValue], new Vector2(randomxpos,transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(delaySpawn);
            Destroy(gameObject, 5f);
        }   
    }
    
}
