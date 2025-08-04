using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa TextMeshPro
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Character : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public Animator anim;

    private Rigidbody2D rig;

    public bool isJumping;
    public bool isDead;
    public GameManager gameManager;

    public static int deathCount = 0; // Agora é acessível de qualquer script
    public TextMeshProUGUI deathCounterText; // Referência ao texto na UI

    private GameController gcPlayer;

    // Start is called before the first frame update
    void Start()
    {
        gcPlayer = GameController.gc;
        gcPlayer.coins = 0;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Atualiza a UI no início
        UpdateDeathCounterUI();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        float inputAxis = Input.GetAxis("Horizontal");

        if (inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        if (inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            isDead = true;
            deathCount++;
            Debug.Log("Game Over! Mortes: " + deathCount);

            UpdateDeathCounterUI();
            gameManager.gameOver();

            Invoke("ResetDeathFlag", 0.5f);
        }
    }

    void ResetDeathFlag()
    {
        isDead = false;
    }

    public static void ResetDeathCount()
    {
        deathCount = 0;
        Debug.Log("Contador de mortes resetado.");
    }

    // Método para atualizar a UI
    void UpdateDeathCounterUI()
    {
        if (deathCounterText != null)
        {
            deathCounterText.text = "Mortes: " + deathCount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            gcPlayer.coins++;
            gcPlayer.coinsText.text = gcPlayer.coins.ToString();
        }
    }




}
