using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

  

    void Start()
    {
        dialogueText.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index]) //ERREUR INDEX
            {
                NextLine();
            }
        }

        // if (dialogueText.text == dialogue[index])
        // {
        //     contButton.SetActive(true);
        // }
        // if (Input.GetKeyDown(KeyCode.F) && dialoguePanel.activeInHierarchy)
        // {
        //     dialoguePanel.SetActive(false);
        // }




    }

    // public void RemoveText()
    // {
    //     if (dialogueText.text == dialogue[index])
    //     {
    //         contButton.SetActive(true);
    //     }
    // }


   

    public void ZeroText()
    {
        //dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray()) //ERREUR INDEX
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        yield return new WaitForSeconds(2f);
        QuitPanel();

        
    }

    public void NextLine()
    {

        // contButton.SetActive(false);

        if (index < dialogue.Length + 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {

            dialoguePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            
        }
    }
    
    // public void QuitButton()
    // {
    //     if(index-1 > dialogue.Length)
    //     {
    //         quitButton.SetActive(false);
    //     }
    // }

    private void QuitPanel()
    {
        
        dialoguePanel.SetActive(false);
        dialogueText.text = string.Empty;  
    }

}
