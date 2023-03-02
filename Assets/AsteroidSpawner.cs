using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public class AsteroidPattern
    {
        public string pattern;

        public int[][] bar1Asteroids;
        public int[][] bar2Asteroids;
        public int[][] bar3Asteroids;
        public int[][] bar4Asteroids;
        public int[][] bar5Asteroids;

        public AsteroidPattern(string pattern,
            int[][] bar1Asteroids, int[][] bar2Asteroids, int[][] bar3Asteroids, int[][] bar4Asteroids, int[][] bar5Asteroids)
        {
            this.pattern = pattern;
            this.bar1Asteroids = bar1Asteroids;
            this.bar2Asteroids = bar2Asteroids;
            this.bar3Asteroids = bar3Asteroids;
            this.bar4Asteroids = bar4Asteroids;
            this.bar5Asteroids = bar5Asteroids;
        }

        public int[][][] getAsteroidsPattern()
        {
            int[][][] pattern = new int[][][]
            {
                this.bar1Asteroids,
                this.bar2Asteroids,
                this.bar3Asteroids,
                this.bar4Asteroids,
                this.bar5Asteroids
            };

            return pattern;
        }
    }


    public GameObject asteroid;
    private int clock;
    public string[] directions;

    // A 3-dimensional array that holds the information for all of the asteroids in the pattern
    private int[][][] currentPattern; 
    private int currentBarTracker;

    AsteroidPattern[] asteroidPatterns;

    public int spawnRate;

    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        directions = new string[] { "left", "right" };
        clock = 0;

        asteroidPatterns = new AsteroidPattern[] {
            new AsteroidPattern("Knockback", 
                                new int[][] { new int[] { }, new int[] { 0, -2, -4 } }, 
                                new int[][] { new int[] { 0, -2, -4 }, new int[] { } }, 
                                new int[][] { new int[] { }, new int[] { 0, 2, 5 } }, 
                                new int[][] { new int[] { 100 } }, 
                                new int[][] { new int[] { 100 } }) ,
            new AsteroidPattern("Kicker",
                                new int[][] { new int[] { 3 }, new int[] { 0 } },
                                new int[][] { new int[] { 0 }, new int[] { -2, -4 } },
                                new int[][] { new int[] { -2 }, new int[] { 0, -4 } },
                                new int[][] { new int[] { 100 } },
                                new int[][] { new int[] { 100 } }) 
        };

        int[][] a = new int[][] { };

        selectPattern();

        currentBarTracker = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (clock > spawnRate) /* To stop the asteroids from spawning rapidly, every frame, a clock
                                * is used to count to a specified number before a new asteroid is
                                * spawned
                                */
        {
            clock = 0; // The clock is reset to 0 whenever an asteroid is about to be spawned


            spawnAsteroids();

           

        } else
        {
            clock += 1; // Increase the clock count, if an asteroid is not being spawned in this update
        }

    }

    private void selectPattern()
    {
        int index = random.Next(0, 2);
        AsteroidPattern pattern = asteroidPatterns[index];

        this.currentPattern = pattern.getAsteroidsPattern();
    }

    private void spawnAsteroids()
    {
        int[][] currentBar = currentPattern[currentBarTracker];

        string direction;

        for (int i = 0; i < 2; i++)
        {
            if (i == 0) direction = "left";
            else direction = "right";

            foreach (int asteroidPos in currentBar[i])
            {
                if (asteroidPos == 100)
                {
                    selectPattern();
                    currentBarTracker = 0;
                    clock = (spawnRate / 2 ) * -1;
                    return;
                }

                GameObject newAsteroid = Instantiate(asteroid, transform.position, transform.rotation); /* Instantiates the asteroid
                    * When instatiating the asteroid, the spawner's current position is passed to it so that the asteroid
                    * spawns in the same place (offscreen to the right, inline with the rocket)
                    */

                AsteroidMove newAsteroidScript = newAsteroid.GetComponent<AsteroidMove>(); // Gets the move script for the asteroid
                                                                                           // so that its setUp function can be called

                newAsteroidScript.setUp(direction, asteroidPos); // Calls the setUp function for the asteroid and passes the direction
                                                                 // and offset variables, which are established above
            }
        }


        currentBarTracker += 1;
    }

}
