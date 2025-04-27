using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManager'ı kullanabilmek için gerekli

public class DoorTrigger : MonoBehaviour
{
    public string sceneToLoad;  // Geçilecek scene adı (Inspector üzerinden ayarlanacak)
    private bool isPlayerNear = false;  // Oyuncu kapının yakınında mı kontrolü

    void Update()
    {
        // Eğer oyuncu kapıya yakınsa ve E tuşuna basılmışsa
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            LoadLevel();  // Yeni scene'e geçiş yap
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer oyuncu kapıya yaklaşırsa, 'E' tuşu için hazır duruma geliriz
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Eğer oyuncu kapıdan uzaklaşırsa, 'E' tuşunu artık kabul etmeyiz
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void LoadLevel()
    {
        // Mevcut karakteri yok et
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Destroy(player);  // Eski karakteri yok et
        }

        // Belirtilen sahneyi yükle
        SceneManager.LoadScene(sceneToLoad);
    }
}
