using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    const int lifeSpan = 2;
    private Timer timer;
    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = lifeSpan;
        timer.Run();
    }
    private void Update()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }
    public void AddForce(Vector2 direction)
    {
        //Apply force
        const float magnitude=15;
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }

}
