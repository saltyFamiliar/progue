using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    private List<Vector2> spritePos = new List<Vector2>
    {
        new Vector2(-2.67f, 0.83f),
        new Vector2(0, 3),
        new Vector2(2.62f, 0.91f)
    };

    private List<string> levels = new List<string>
    {
        "SampleScene",
        "SampleScene",
        "SampleScene"
    };
    
    int currentSpritePos = 0;
    
    
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (currentSpritePos == 0) return;
            currentSpritePos--;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (currentSpritePos == spritePos.Count - 1) return;
            currentSpritePos++;
        } else if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(levels[currentSpritePos]);

        }
        
        transform.position = spritePos[currentSpritePos];
    }
}
