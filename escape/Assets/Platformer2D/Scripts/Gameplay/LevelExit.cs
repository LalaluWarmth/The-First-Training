﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieMarc.Platformer
{
    public class LevelExit : MonoBehaviour
    {
        [Header("Entrance")]
        public int index;
        public Vector2 entrance_offset;

        [Header("Exit")]
        public string go_to_level = "";
        public int go_to_index = 0;

        private static List<LevelExit> levelExits = new List<LevelExit>();

        private void Awake()
        {
            levelExits.Add(this);
        }

        private void OnDestroy()
        {
            levelExits.Remove(this);
        }

        void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }

        void Update()
        {

        }

        public Vector3 GetEntryPosition()
        {
            return transform.position + new Vector3(entrance_offset.x, entrance_offset.y, 0f);
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.GetComponent<PlayerCharacter>())
            {
                if (go_to_level != "")
                {
                    SceneNav.GoToLevel(go_to_level, go_to_index);
                }
            }
        }

        public static LevelExit Get(int index)
        {
            foreach (LevelExit exit in levelExits)
            {
                if (exit.index == index)
                {
                    return exit;
                }
            }
            return null;
        }
    }

}