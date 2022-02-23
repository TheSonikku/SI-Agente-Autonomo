using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    public int counter;
    public Counter counterText;
    private Vector2 logPosition = Vector2.zero;
    private Vector2 boatPosition = Vector2.zero;
    private Vector2 boatDirection = Vector2.zero;
    private Rigidbody2D boatBody;

    private float velMagnitude = 5f;
    private float torMagnitude = 10f;

    public GameEngine game;
    public void LogPos(float x, float y)
    {
        logPosition = new Vector2(x, y);
        boatPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        boatDirection = new Vector2(logPosition.x - boatPosition.x, logPosition.y - boatPosition.y);
        boatDirection.Normalize();
    }
    private void OnCollisionEnter2D(Collision2D logCollision){
        LogEngine logTest = logCollision.gameObject.GetComponent<LogEngine>();
        if (logTest != null){
            Destroy(logCollision.gameObject);
            counter += 1;
            counterText.GetComponent<UnityEngine.UI.Text>().text = counter.ToString();
            boatBody.velocity = Vector2.zero;
            boatBody.angularVelocity = 0;
            boatDirection = Vector2.zero;
            game.spawnLog();
        }
    }
    void Start()
    {
        counter = 0;
        boatBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (boatDirection != Vector2.zero){
            boatBody.AddForce(boatDirection * velMagnitude);
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, boatDirection);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, torMagnitude);
        }
    }
}
