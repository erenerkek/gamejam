using UnityEngine;
using Cinemachine;

public class BossFightTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Camera
    public Transform player;                       // Oyuncu
    public Transform bossFightTarget;              // Boss fight alanındaki hedef
    public GameObject bossHealthBarUI;             // Boss can barı (isteğe bağlı)
    public GameObject invisibleWall;               // Görünmez duvar (isteğe bağlı)

    private bool isFocusSet = false;               // Kameranın odaklanıp odaklanmadığını kontrol eden bayrak

    public float cameraTransitionSpeed = 2f; // Kamera geçişinin hızını ayarlamak için (daha büyük değer = daha yavaş geçiş)

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFocusSet)
        {
            // Boss fight başladığında kamerayı boss fight alanına yönlendir
            virtualCamera.Follow = bossFightTarget;
            virtualCamera.LookAt = bossFightTarget;  // Kameranın bakışını da yönlendir

            // Kameranın geçiş hızını ayarla
            virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = cameraTransitionSpeed;
            virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = cameraTransitionSpeed;

            // Boss fight UI'larını etkinleştir
            if (bossHealthBarUI != null)
                bossHealthBarUI.SetActive(true);

            // Görünmez duvarı etkinleştir
            if (invisibleWall != null)
                invisibleWall.SetActive(true);

            // Odaklama bir kere yapılacak, bayrağı true yapıyoruz
            isFocusSet = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Burada kamera odaklanmıyor, sadece UI'yi ve duvarı devre dışı bırakıyoruz
            if (isFocusSet)
            {
                // Boss fight bitince UI'ları ve invisible wall'ı devre dışı bırak
                if (bossHealthBarUI != null)
                    bossHealthBarUI.SetActive(false);

                if (invisibleWall != null)
                    invisibleWall.SetActive(false);
            }
        }
    }
}
