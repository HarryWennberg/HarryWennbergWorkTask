using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Game
{

    public class LevelCreation : MonoBehaviour
    {
        public int openingDirection;
        private int random;
        private bool spawn = false;
        private static int counter = 0;
        public static int maxNumberRooms = 14;

        private RoomSpawner roomSpawner;

        private void Start()
        {            
            roomSpawner = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomSpawner>();
            Invoke("Spawn", 0.5f);
        }


        void Spawn()
        {
            if (spawn == false && counter < maxNumberRooms)
            {

                if (openingDirection == 1)
                {

                    random = Random.Range(0, roomSpawner.bottomRooms.Length);
                    Instantiate(roomSpawner.bottomRooms[random], transform.position, roomSpawner.bottomRooms[random].transform.rotation);

                }
                else if (openingDirection == 2)
                {

                    random = Random.Range(0, roomSpawner.topRooms.Length);
                    Instantiate(roomSpawner.topRooms[random], transform.position, roomSpawner.topRooms[random].transform.rotation);

                }
                else if (openingDirection == 3)
                {

                    random = Random.Range(0, roomSpawner.leftRooms.Length);
                    Instantiate(roomSpawner.leftRooms[random], transform.position, roomSpawner.leftRooms[random].transform.rotation);

                }
                else if (openingDirection == 4)
                {

                    random = Random.Range(0, roomSpawner.rigthRooms.Length);
                    Instantiate(roomSpawner.rigthRooms[random], transform.position, roomSpawner.rigthRooms[random].transform.rotation);

                }

                counter++;
                spawn = true;
            }

            if (spawn == false && counter == maxNumberRooms)
            {
                if (openingDirection == 1)
                {

                    Instantiate(roomSpawner.closedRoom, transform.position, Quaternion.identity);
                    //Destroy(gameObject);

                }
                else if (openingDirection == 2)
                {


                    Instantiate(roomSpawner.closedRoom, transform.position, Quaternion.identity);
                   // Destroy(gameObject);

                }
                else if (openingDirection == 3)
                {

                    Instantiate(roomSpawner.closedRoom, transform.position, Quaternion.identity);
                    //Destroy(gameObject);

                }
                else if (openingDirection == 4)
                {

                    Instantiate(roomSpawner.closedRoom, transform.position, Quaternion.identity);
                    //Destroy(gameObject);

                }
                spawn = true;
            }


        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("SpawnPoint"))
            {
                if (other.GetComponent<LevelCreation>().spawn == false && spawn == false)
                {
                    Instantiate(roomSpawner.closedRoom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                spawn = true;
            }
        }
    }
}
