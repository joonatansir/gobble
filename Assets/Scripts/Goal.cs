
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
	public int Points = 0;
	public Text PointText;

	private bool _gameOver = false;
	
	// Update is called once per frame
	void Update ()
	{
		if (_gameOver)
		{
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonDown(0))
			{
				Time.timeScale = 1.0f;
				SceneManager.LoadScene("Main");
			}
		}
		else
		{
			PointText.text = Points.ToString();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("trash"))
		{
			Points++;
		}
		else if (other.CompareTag("seal"))
		{
			PointText.text = "You ate a seal :(";
			_gameOver = true;
		}
	}
}
