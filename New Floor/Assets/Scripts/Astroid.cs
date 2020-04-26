using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Astroid logic
public class Astroid : MonoBehaviour
{
    [SerializeField]
    private GameObject astroid;
    [SerializeField]
    private Sprite astroidSprite0;
    [SerializeField]
    private Sprite astroidSprite1;
    [SerializeField]
    private Sprite astroidSprite2;

    //Pick random sprite and send off in a direction
    public void Initialize(Direction moveDirection, Vector2 location)
    {
        //Direction direction;
        SpawnAstroid(location);
        AddForce(moveDirection);
    }
    public void AddForce(Direction moveDirection)
    {
        //Apply force
        const float MinImpulseForce = 0.75f;
        const float MaxImpulseForce = 2f;
        float baseAngle;
        if (moveDirection == Direction.Up)
        {
            baseAngle = 75;
        } else if (moveDirection == Direction.Down)
        {
            baseAngle = -105;
        }
        else if (moveDirection == Direction.Left)
        {
            baseAngle = 165;
        }
        else
        {
            baseAngle = -15;
        }
        float angle = Random.Range(0, 30);
        angle = (angle* Mathf.Deg2Rad) + (baseAngle*Mathf.Deg2Rad);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction* magnitude,
            ForceMode2D.Impulse);

    }
    private void SpawnAstroid(Vector3 location)
    {

        gameObject.transform.position = location;//worldLocation;

        // set random sprite for the astroid
        SpriteRenderer spriteRenderer = astroid.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = astroidSprite0;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = astroidSprite1;
        }
        else
        {
            spriteRenderer.sprite = astroidSprite2;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            Vector3 astroidSize = gameObject.transform.localScale;
            astroidSize.x = astroidSize.x / 2;
            astroidSize.y = astroidSize.y / 2;
            gameObject.transform.localScale = astroidSize;
            gameObject.GetComponent<CircleCollider2D>().radius *= 0.5f;
            if (!(gameObject.transform.localScale.x < 0.25))
            {
                
            }
            else
            {
                if (GameObject.FindGameObjectsWithTag("Astroid").Length == 0)
                {
                    Debug.Log("Switch Scene");
                }
            }
            
            Destroy(collision.otherCollider.gameObject);
            Destroy(collision.gameObject);

        }
    }
}
