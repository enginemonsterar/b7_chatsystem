using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField chatInputField;
    [SerializeField] private GameObject chatItemPrefab;
    [SerializeField] private GameObject chatItemOwnPrefab;
    [SerializeField] private Transform content;

    private List<string> chatValue = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        chatValue.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sit amet dapibus justo, quis semper sem. Ut vehicula sit amet nisi eget gravida. Nunc in orci vehicula, facilisis felis ut, accumsan erat. Maecenas pharetra sem condimentum vestibulum elementum. Sed finibus rhoncus augue id dictum. Vestibulum sit amet auctor libero. Nulla aliquam erat sit amet tellus semper, non condimentum risus gravida. Aliquam dictum rutrum pretium. Pellentesque malesuada, est vulputate molestie facilisis, elit dui molestie massa, vitae fringilla eros nisi eget lectus. Maecenas convallis ultrices tristique. In accumsan tempus lectus, non finibus sem fermentum id.");
        chatValue.Add("Aliquam erat volutpat. Fusce a orci neque. Integer interdum elit vel justo interdum hendrerit. Maecenas id congue diam. Mauris a sapien purus. Aliquam sed metus sed turpis lacinia blandit tincidunt vel est. Nam augue neque, suscipit vel consequat in, elementum a neque.");
        chatValue.Add("Hello world");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnOtherChat(){
        StartCoroutine(SpawnOtherChat_());
    }

    public void SendChat(){
        string chatValue = chatInputField.text;

        if(chatValue != ""){
            chatInputField.text = "";
            StartCoroutine(SpawnOwnChat_(chatValue));
        }

    }
    IEnumerator SpawnOwnChat_(string chatValue){
        GameObject chatItem = null;
        
        chatItem = Instantiate(chatItemOwnPrefab, content);        
        chatItem.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = chatValue;

        yield return new WaitForEndOfFrame();
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        content.parent.GetComponent<ScrollRect>().verticalNormalizedPosition  = 0f;
        
    }

    IEnumerator SpawnOtherChat_(){
        GameObject chatItem = null;
        
        chatItem = Instantiate(chatItemPrefab, content);
        chatItem.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Someone";        

        chatItem.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = chatValue[Random.Range(0, chatValue.Count)];
        yield return new WaitForEndOfFrame();
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
        content.parent.GetComponent<ScrollRect>().verticalNormalizedPosition  = 0f;
        
    }
}
