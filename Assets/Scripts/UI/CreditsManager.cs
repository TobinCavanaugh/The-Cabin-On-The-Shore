using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace UI
{
    public class CreditsManager : MonoBehaviour
    {
        private string filLoc;
        
        public void OpenFile()
        {
            Awake();
            OpenWithDefaultProgram();
        }
        
        public void OpenWithDefaultProgram()
        {
            Debug.Log(filLoc);
            Process.Start("notepad", filLoc);
        }
        
        private void Awake()
        {
            filLoc = $"{Application.persistentDataPath}/LakeGameCredits.txt";

            FileStream f;
            if (!File.Exists(filLoc))
            {
                f = File.Create(filLoc);
            }
            else
            {
                f = File.Open(filLoc, FileMode.Open);
            }


            string data = 
                
            "[SOUNDS]"+ "\n" +
            "https://freesound.org/people/Nox_Sound/sounds/544853/" + "\n" +
            "https://freesound.org/people/unfa/sounds/258339/ " + "\n" +
            "https://freesound.org/people/Benboncan/sounds/67884/" + "\n" +
            "https://freesound.org/people/falcospizaetus/sounds/489949/" + "\n" +
            "https://freesound.org/people/dkiller2204/sounds/422969/" + "\n" +
            "https://freesound.org/people/dkiller2204/sounds/422967/" + "\n" +
            "https://freesound.org/people/scotchio/sounds/143915/" + "\n" +
            "https://freesound.org/people/dheming/sounds/177778/" + "\n" +
            "https://freesound.org/people/Bird_man/sounds/316744/" + "\n" +
            "https://freesound.org/people/MoiraM/sounds/491210/" + "\n" +
            "https://freesound.org/people/Jace/sounds/35291/" + "\n" +
            "https://freesound.org/people/waveplaySFX/sounds/329593/" + "\n" +
            "https://freesound.org/people/Greg_Surr/sounds/590160/" + "\n" +
            "https://freesound.org/people/pcmac/sounds/464529/" + "\n" +
            "https://freesound.org/people/jazbavac/sounds/198524/" + "\n" +
            "https://freesound.org/people/dster777/sounds/344548/" + "\n" +
            "https://freesound.org/people/Isaac200000/sounds/336151/" + "\n" +
            "https://freesound.org/people/alexbird/sounds/46514/" + "\n" +
            "https://freesound.org/people/SirBedlam/sounds/393824/" + "\n" +
            "https://freesound.org/people/markfrancombe/sounds/17563/" + "\n" +
            "https://freesound.org/people/rastataper/sounds/56044/" + "\n" +
            "https://freesound.org/people/waveplaySFX/sounds/620113/" + "\n" +
            "https://freesound.org/people/waveplaySFX/sounds/554867/"+ "\n" +
            "\n" +
            "[SHADERS]"+ "\n" +
            "Retro 3D Shader Pack : leakyfingers.itch.io  |  twitter.com/leakyfingers"+ "\n" +
            "PSX Shader Pack : https://twitter.com/oh_no_valerie" + "\n" +
            "\n" +
            "[MODELS]" + "\n" +
            "Old Lady Model : https://twitter.com/LironHero"
            
            
            ;



            var dat = new UTF8Encoding(true).GetBytes(data);
            f.Write(dat, 0, data.Length);
            
            f.Close();
        }
    }
}