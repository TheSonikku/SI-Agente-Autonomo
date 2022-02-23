using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject LogPose;
    private SpriteRenderer LogSpriteR;
    public ShipEngine sunny;

    public void spawnLog()
    {
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0 + LogSpriteR.sprite.rect.height/2)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - LogSpriteR.sprite.rect.height/2)).y);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0 + LogSpriteR.sprite.rect.width/2, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - LogSpriteR.sprite.rect.width/2,  0)).x);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        Instantiate(LogPose, spawnPosition, randomRotation);
        sunny.LogPos(spawnX, spawnY);
    }

    void Start()
    {
        LogSpriteR = LogPose.GetComponent<SpriteRenderer>();
        spawnLog();
    }
}
