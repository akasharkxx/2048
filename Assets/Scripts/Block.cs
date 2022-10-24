using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Two048
{
    public class Block : MonoBehaviour
    {
        public int Value;
        public Node Node;
        public Block MergingBlock;
        public bool Merging;
        public Vector2 Pos => transform.position;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private TextMeshPro _text; 

        public void Init(BlockType type)
        {
            Value = type.Value;
            _renderer.color = type.Color;
            _text.SetText(type.Value.ToString());
        }

        public void SetBlock(Node node)
        {
            if (Node != null) Node.OccupiedBlock = null;
            Node = node;
            Node.OccupiedBlock = this;
        }

        public void MergeBlock(Block blockToMergeWith)
        {
            // Set the block we are merging with
            MergingBlock = blockToMergeWith;

            // Set current node as occupied to be used by other blocks
            Node.OccupiedBlock = null;

            // Set the base block as merging so it doesn't get used again
            blockToMergeWith.Merging = true;
        }
    }
}

