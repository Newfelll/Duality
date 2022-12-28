using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject bubbleG;
    private Vector2 spawnPos =new Vector2(16,0.41f);


    public TextMeshProUGUI fpsText;
    private float pollingTime=1f;
    private float time;
    private int frameCount;
    private float repeatRate = 4;
    


    // Start is called before the first frame update
    void Start()
    {   
        
        Application.targetFrameRate = 60;
        // StartCoroutine(MyCoroutine());
        InvokeRepeating("SpawnBubble", 2, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        repeatRate -= Time.deltaTime ;
        time += Time.deltaTime;
        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount/time);
            fpsText.text = frameRate.ToString()+"FPS";

            time -= pollingTime;
            frameCount = 0;


        }
    }



    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
    }


    void SpawnBubble()
    {
        if (Random.value < 0.5)
        {
            spawnPos.y = -0.68f;
        }
        else spawnPos.y = 0.548f;
        Instantiate(bubbleG,spawnPos,bubbleG.transform.rotation);
    }
   public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
