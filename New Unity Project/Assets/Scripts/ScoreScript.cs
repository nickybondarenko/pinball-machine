using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreField;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ScoreFieldUpdate();
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") {
            Score = Score + 100;
            ScoreFieldUpdate();
        }
    }

    private void ScoreFieldUpdate(){
        ScoreField.text = "Punkte: " + Score.ToString();
    }
}
