using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float speed = 5f;         // Lazerin hızı
    public float lifeTime = 5f;       // Kaç saniye sonra yok olsun

    void Start()
    {
        Destroy(gameObject, lifeTime); // Belirli süre sonra lazeri yok et
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime); // Aşağı doğru hareket et
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("player hasasr aldı");
            Destroy(gameObject);
        }
        // Eğer lazer, "Ground" veya "Player" tagine sahip bir nesneye çarparsa
        if( collision.CompareTag("Ground"))
        {
            Destroy(gameObject); // Lazer yok olsun
        }
    }
}
