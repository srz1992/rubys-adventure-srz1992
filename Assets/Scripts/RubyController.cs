using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    
    public int health { get { return currentHealth; }}
    int currentHealth;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    bool isInvincible;
    float invincibleTimer;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible) {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0) {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate() {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount) {

        if (amount < 0) {
            if (isInvincible) {
                return ;
            }
            // when taking damage, if isInvisible is currently false, set it to true.
            // then set the timer to timeInvincible
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
            
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);

    }
}
