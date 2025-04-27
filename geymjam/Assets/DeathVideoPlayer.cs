using UnityEngine;
using UnityEngine.Video;

public class DeathVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Video Player referansı
    public string nextSceneName = "Hub";  // Sahne adı, ihtiyaç olursa değiştirebilirsiniz

    void Start()
    {
        // Scene geçişinde bu objenin yok olmasını engelle
        DontDestroyOnLoad(gameObject);
    }

    public void PlayDeathVideo()
    {
        // Video Player'ı başlat
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();
    }

    public void StopDeathVideo()
    {
        // Video durdur
        videoPlayer.Stop();
    }
}