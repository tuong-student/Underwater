using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    #region Components
    GameObject piratePrefabs;
    #endregion

    #region Stats
    [SerializeField] float radiusAroundPlayer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (GameManager.InsGameManager.isFinish == false)
        {
            var degrees = UnityEngine.Random.Range(0, 360);
            var radians = degrees * Mathf.Deg2Rad;
            var x = Mathf.Cos(radians);
            var y = Mathf.Sin(radians);
            Vector3 pos1 = new Vector3(x, y, 0f);
            Vector3 posRadius = pos1 * radiusAroundPlayer;
            yield return new WaitForSeconds(3f);
            if(GameManager.InsGameManager.isFinish == false)
                Instantiate(PrefabsManager.i.PiratePrefabs, posRadius, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, radiusAroundPlayer);
    }
}
