using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GrpBurger4P : MonoBehaviour {

	public AudioSource GameCoinSound; 
	private Animator GameOneAnimator;

	//stores teamScore
	private int teamScore;
	//stores string of anim boolean
	private string BurgerAnimTransition;

	// Boolean for whether burger is animating
	private bool isBurgerAnimating = false;

	//stores string of current teamScore
	public Text ScoreText;

	// Use this for initialization
	void Start () {
		GameOneAnimator = GetComponent<Animator> ();

		teamScore = 0;
		isBurgerAnimating = false;

	}

	public void BurgerAnim() {
		if (isBurgerAnimating) {
			return;
		} 

		else {
			GainPoint ();
		}
	}

	public void GainPoint() {
		isBurgerAnimating = true;

		//play animation
		teamScore += 1;
		BurgerAnimTransition = "BurgerScore" + teamScore.ToString () + "Clicked";
		GameOneAnimator.SetBool (BurgerAnimTransition, true);
		GameCoinSound.Play ();

		StartCoroutine (resetBurgerAnim());
	}

	IEnumerator resetBurgerAnim() {
		//check if a team has won = gameover
		if (teamScore == 10) {
			
		} 
		//else reset animation
		else {
			yield return new WaitForSeconds (1.65f);
			isBurgerAnimating = false;
			GameCoinSound.Stop ();
		}
	}
}
