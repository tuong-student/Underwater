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
        while (true)
        {
            float r = Random.Range(-1, 1);
            Vector3 pos1 = new Vector3(Mathf.Cos(r), Mathf.Sin(r), 0f);
            Vector3 posRadius = pos1 * radiusAroundPlayer;
            yield return new WaitForSeconds(3f);
            Instantiate(PrefabsManager.i.PiratePrefabs, posRadius, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, radiusAroundPlayer);
    }
}
