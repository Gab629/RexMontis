using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Variables pour le temps
    private float tempsDejeu = 60f;
    private float tempsDeDepart;
    static private float tempsFinal = 0f;
    private float interval = 2;

    //Variables pour le score
    private int score;
    static private string pointageFinal;
    private float hauteurTemplate = 60f;
    private List<tableScores> listeDesScores;
    private List<Transform> listeDesTransformDesScores;
    public GameObject tableauDesScores;
    public float pointIncreasedPerSecond;

    //Variables non-class�es
    public GameObject character;
    private string scene;
    static private string nomDuJoueur;

    [Header("UI Elements")]

    public Text champsTemps;
    public Text champsScore;
    public Text champsNomEntre;
    public Text champsNom;
    public Transform scoreContainer;
    public Transform scoreTemplate;

     //Test pour l'accueil
     public bool gameIsStarted = false;

/*      public List<playersList> playersList; */
 /*    private GameObject[] arrayPlayers; */

    // Score Points --------------------------------------------------------------------------------------------
    public float scoreJoueur1 = 0;
    public float scoreJoueur2 = 0;
    public float scoreJoueur3 = 0;
    public float scoreJoueur4 = 0;
    public float scoreJoueur5 = 0;
    public float scoreJoueur6 = 0;
    public float scoreJoueur7 = 0;
    public float scoreJoueur8 = 0; 
    public List<tableData> CounterObjects = new List<tableData>();
    public struct tableData{
        public Transform scoreTransform;
        public tableScores Score;
    }
    public float scoreBonus1 = 10f;
        public float scoreBonus2 = 10f;
            public float scoreBonus3 = 10f;
                public float scoreBonus4 = 10f;
                    public float scoreBonus5 = 10f;
                        public float scoreBonus6 = 10f;
                            public float scoreBonus7 = 10f;
                                public float scoreBonus8 = 10f;

    private GameObject parentScoreSupprimable;
    private GameObject scoreSupprimable;
    public List<GameObject> Players {get; set;}



    private void AjouterScore(tableScores tableDesScores, Transform container, List<Transform> listeDeTransform)
    {
        Transform scoreTransform = Instantiate(scoreTemplate, container); // Crée un clone dans un container
        RectTransform scoreRectTransform = scoreTransform.GetComponent<RectTransform>(); // Va chercher la position du clone 
        scoreRectTransform.anchoredPosition = new Vector2(hauteurTemplate * listeDeTransform.Count, 0 );  //Descend le score cloné d'une certaine hauteur
        scoreTransform.gameObject.SetActive(true); // Active le clone 
        tableData data = new tableData();
        data.scoreTransform = scoreTransform;
        data.Score = tableDesScores;
        CounterObjects.Add(data);
        


        // --- Crée les positions --- //
        int rang = listeDeTransform.Count + 1;
        string rangString;
        switch (rang)
        {
            default: rangString = rang + "e"; break;
            case 1: rangString = "1er"; break;
        }


        scoreTransform.Find("positionText").GetComponent<Text>().text = rangString;

        float scoreText = tableDesScores.scoreUnique;
        scoreTransform.Find("nomsText").GetComponent<Text>().text = scoreText.ToString();

        string nomsText = tableDesScores.nomUnique;
        scoreTransform.Find("scoreText").GetComponent<Text>().text = nomsText;
    

        listeDeTransform.Add(scoreTransform);
        
        
    }

    //Repr�sente un seul score et un seul nom
    public class tableScores   
    {
        public float scoreUnique;
        public string nomUnique;

    }

    void Start()
    {
            listeDesScores = new List<tableScores>()
        {
            
            new tableScores { scoreUnique = scoreJoueur1, nomUnique = "Max" },
            new tableScores { scoreUnique = scoreJoueur2, nomUnique = "Caro" },
            new tableScores { scoreUnique = scoreJoueur3, nomUnique = "Gab" },
            new tableScores { scoreUnique = scoreJoueur4, nomUnique = "Jerry" },
            new tableScores { scoreUnique = scoreJoueur5, nomUnique = "J�" },
            new tableScores { scoreUnique = scoreJoueur6, nomUnique = "Sam" },
            new tableScores { scoreUnique = scoreJoueur7, nomUnique = "Mik" },
            new tableScores { scoreUnique = scoreJoueur8, nomUnique = "Rudy" },
            
        };
 

        //Met les scores dans le bon ordre
        for (int i = 0; i < listeDesScores.Count; i++)
        {
            for (int j = i + 1; j < listeDesScores.Count; j++)
            {
                if(listeDesScores[j].scoreUnique > listeDesScores[i].scoreUnique)
                {
                    //Interchange les positions
                    tableScores temporaire = listeDesScores[i];
                    listeDesScores[i] = listeDesScores[j];
                    listeDesScores[j] = temporaire;
                }
            }
        }
        listeDesTransformDesScores = new List<Transform>();

            foreach(tableScores tableDesScores in listeDesScores)
            {
             AjouterScore(tableDesScores, scoreContainer, listeDesTransformDesScores);
            }
  
       
        
        scene = SceneManager.GetActiveScene().name;

        if (scene == "Scene1"){
            champsNom.text = nomDuJoueur;
            if (champsNom.text == "")
            {
                champsNom.text = "Joueur";
            }
            tempsDeDepart = tempsDejeu;

        }else if (scene == "Fin")
        {
            champsNom.text = nomDuJoueur;
            if (champsNom.text == "")
            {
                champsNom.text = "Joueur";
            }
            champsTemps.text = tempsFinal.ToString();
            champsScore.text = pointageFinal;
            
        }

        //Test pour l'accueil
/*         playersList = new List<playersList>(); */

        Players = new List<GameObject>();

    }

    
    void Update()
    {
        //Test pour l'accueil
        /*         GameObject[] players;

                player = GameObject.FindGameObjectsWithTag("Player");

                Debug.Log(players); */

        /*         arrayPlayers.Add(GameObject.FindGameObjectsWithTag("Player") as GameObject);

                Debug.Log(arrayPlayers.length); */

        // scoreSupprimable = parentScoreSupprimable.transform.GetChild(0).gameObject;
        Debug.Log(scoreJoueur1);

        scoreTemplate.gameObject.SetActive(false);
        CounterObjects[0].Score.scoreUnique = scoreJoueur1;
        CounterObjects[1].Score.scoreUnique = scoreJoueur2;
        CounterObjects[2].Score.scoreUnique = scoreJoueur3;
        CounterObjects[3].Score.scoreUnique = scoreJoueur4;
        CounterObjects[4].Score.scoreUnique = scoreJoueur5;
        CounterObjects[5].Score.scoreUnique = scoreJoueur6;
        CounterObjects[6].Score.scoreUnique = scoreJoueur7;
        CounterObjects[7].Score.scoreUnique = scoreJoueur8;

       foreach(tableData data in CounterObjects)
       {
        
        float scoreText = data.Score.scoreUnique;
        data.scoreTransform.Find("nomsText").GetComponent<Text>().text = scoreText.ToString();

        string nomsText = data.Score.nomUnique;
        data.scoreTransform.Find("scoreText").GetComponent<Text>().text = nomsText;
       }


        //
        Players.Add(character);



        if (gameIsStarted) {
            Decompte();
            Score();
        }
    }

    // void DestroyScore()
    // {
    //     Destroy(scoreSupprimable);
    // }

    public void Decompte()
    {   
        if(scene != "Intro" && scene != "Fin")
        {
            // if (tempsDejeu <= 99f && tempsDejeu > 9f)
            // {
            //     champsTemps.text = "00:" + Mathf.Ceil(tempsDejeu);

            // }else if(tempsDejeu <= 9f)
            // {
            //     champsTemps.text = "00:0" + Mathf.Ceil(tempsDejeu);
            // }


            // tempsDejeu -= 1 * Time.deltaTime;

            if (tempsDejeu <= 0)
            {
                tempsDejeu = 0;
                FinDeJeu();
            }
        }
        
    }

  
    public void Score()
    {
        if(scene != "Intro" && scene != "Fin")
        {
            //score = character.GetComponent<Character>().scorePerso;
            interval -= 1 * Time.deltaTime;
           
            // Debug.Log(scoreJoueur2);
            
            if(interval <= 0){
       
                interval += 2f;

                if(tempsDejeu >= 30){
                scoreJoueur1 += scoreBonus1;
                scoreJoueur2 += scoreBonus2;
                scoreJoueur3 += scoreBonus3;
                scoreJoueur4 += scoreBonus4;
                scoreJoueur5 += scoreBonus5;
                scoreJoueur6 += scoreBonus6;
                scoreJoueur7 += scoreBonus7;
                scoreJoueur8 += scoreBonus8;
                                
                }else{
                scoreJoueur1 += scoreBonus1 + 30f;
                scoreJoueur2 += scoreBonus2 + 30f;
                scoreJoueur3 += scoreBonus3 + 30f;
                scoreJoueur4 += scoreBonus4 + 30f;
                scoreJoueur5 += scoreBonus5 + 30f;
                scoreJoueur6 += scoreBonus6 + 30f;
                scoreJoueur7 += scoreBonus7 + 30f;
                scoreJoueur8 += scoreBonus8 + 30f;
                }
                
            }

           

            if(score >= 1000)
            {
                champsScore.text = "Score : " + score;
            }
            else if (score >= 100)
            {
                champsScore.text = "Score : 0" + score;
            }
            else if (score >= 10)
            {
                champsScore.text = "Score : 00" + score;
            }
            else if(score >= 0)
            {
                champsScore.text = "Score : 000" + score;
            }

            if (Input.GetKeyDown(KeyCode.F1) && tableauDesScores.activeSelf == true)
            {
                tableauDesScores.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.F1) && tableauDesScores.activeSelf == false)
            {
                tableauDesScores.SetActive(true);
            }

        } 
    }

    public void Jouer(){
        SceneManager.LoadScene("Scene1");
        nomDuJoueur = champsNomEntre.text;

    }

    public void FinDeJeu()
    {
        SceneManager.LoadScene("Fin");
        tempsFinal = tempsDeDepart - tempsDejeu;
        pointageFinal = champsScore.text;
        
    }


    











































}
