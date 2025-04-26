using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class NPC : MonoBehaviour
{

    [SerializeField] private List<string> startList; // oyuna basladıgında
    [SerializeField] private List<string> list1;  // ilk bosu kesemeden calıssacak olunce
    [SerializeField] private List<string> list2; // ilk bosu kesitin ikinci kesemeidn
    [SerializeField] private List<string> endList; // ikinci bosuda kestion oyun sonu


    [SerializeField] GameObject panel;

    [SerializeField] private TextMeshPro textComponent;

    private bool isPanelActive = false;
    private int index = 0;

     [SerializeField] private List<List<string>> currentLists = new();
     private List<string> currentList = new();
    void Awake()
    {
       //  currentList = PlayerPrefs.GetInt("listindex",0);
       currentLists.Add(startList);
        currentLists.Add(list1);

       currentLists.Add(list2);
        currentLists.Add(endList);


    }

    [ContextMenu("increase")]
    public void Increase()
    {
        PlayerPrefs.SetInt("listindex", PlayerPrefs.GetInt("listindex",0) + 1); // burası karakterin ölüdğü yerde calısacak

        currentList= currentLists[PlayerPrefs.GetInt("listindex",0)];
    }


    void Start()
    {
        currentList= currentLists[PlayerPrefs.GetInt("listindex",0)];
        Debug.Log("asdsad");

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OpenPanel();
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ClosePanel();
        }
    }
  

private void OpenPanel()
{
    var x = Random.Range(0,currentList.Count);
    textComponent.text=currentList[x];
    panel.SetActive(true);
    
}
    private void ClosePanel()
{
    isPanelActive = false; // Panel kapanınca kontrolü sıfırla
    panel.SetActive(false);
}
}

// bosu kesitiğinde artacak ilk başlangıc kodu da oyun başladıgı zaman olacak  
// 1. bos oldugundeki yere kod 
// 2. bos oldugundeki yere ekleyecek
// boslar bitince ekleyecek