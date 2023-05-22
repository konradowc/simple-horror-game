using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Events.events.onNewspaperGet += updateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateUI()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text =
            "Newspapers: " + GameFlow.game.newspaperCount + "/6";
    }
}
