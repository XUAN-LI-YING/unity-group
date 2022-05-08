
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text speakerName, dialogue;
    public TextMeshProUGUI navButtonText;
    public Image speakerSprite;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance=this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public static void StartConversation(Conversation convo)
    {
        instance.currentIndex=0;
        instance.currentConvo=convo;
        instance.speakerName.text="";
        instance.dialogue.text="";
        instance.navButtonText.text= ">";
        instance.ReadNext();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            instance.ReadNext();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            instance.ReadNext();
        }
    }


    public void ReadNext()
    {
        if(currentIndex>currentConvo.GetLength())
        {
            
            SceneManager.LoadScene("level");
            return;
        }
        speakerName.text=currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
        dialogue.text=currentConvo.GetLineByIndex(currentIndex).dialogue;
        speakerSprite.sprite=currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
        currentIndex++;
        Debug.Log(currentIndex);
    }
}
