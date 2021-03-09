using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 1);
            if (_playerMovement.totalKibi >= 4)
            {
                SceneManager.LoadScene(2);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 0);
        }

        private void Update()
        {
            
                curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);
/*
                foreach (var r in runes)
                {
                    r.color = curColor;
                }
                */
            if (_playerMovement.totalKibi == 1)
            {
                runes[0].color = curColor;
            }
            
            else if (_playerMovement.totalKibi == 2)
            {
                runes[0].color = curColor;
                runes[1].color = curColor;
            }
            else if (_playerMovement.totalKibi == 3)
            {
                runes[0].color = curColor;
                runes[1].color = curColor;
                runes[2].color = curColor;
            }
            else if (_playerMovement.totalKibi >= 4)
            {
                runes[0].color = curColor;
                runes[1].color = curColor;
                runes[2].color = curColor;
                runes[3].color = curColor;
            }

            
            
        }
    }
}
