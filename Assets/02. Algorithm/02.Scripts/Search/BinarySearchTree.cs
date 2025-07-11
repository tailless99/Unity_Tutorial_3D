using System;
using UnityEngine;

public class BinarySearchTree : MonoBehaviour {
    /* 
     * 중첩 클래스 
     * BinarySearchTree 안에서는 사용하는 클래스지만, 다른 클래스에서는 필요없을때
     * 클래스 안에서 선언한다.
    */
    public class TreeNode {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value) {
            this.value = value;
        }
    }

    private TreeNode root;
    private int[] array = { 8, 3, 10, 1, 6, 14, 4, 7, 13 };

    private string result;

    private void Start() {
        foreach(var v in array)
            Insert(root, v);

        PreOrder(root);
        Debug.Log($"PreOrder : {result.TrimEnd(',')}");

        result = String.Empty;
        InOrder(root);
        Debug.Log($"InOrder : {result.TrimEnd(',')}");

        result = String.Empty;
        PostOrder(root);
        Debug.Log($"PostOrder : {result.TrimEnd(',')}");
    }

    private TreeNode Insert(TreeNode node, int V) {
        // 초기에 루트 노드가 비었을 때
        if(node == null) return new TreeNode(V);

        if(V < node.value)
            node.left = Insert(node.left,V);
        else
            node.right = Insert(node.right, V);
        
        return node;
    }

    private void PreOrder(TreeNode node) { // 전위 순회
        if (node == null) return;

        result += $"{node.value}, ";
        PreOrder(node.left);
        PreOrder(node.right);
    }

    private void InOrder(TreeNode node) { // 중위 순회
        if (node == null) return;

        InOrder(node.left);
        result += $"{node.value}, ";
        InOrder(node.right);
    }

    private void PostOrder(TreeNode node) { // 후위 순회
        if (node == null) return;

        PostOrder(node.left);
        PostOrder(node.right);
        result += $"{node.value}, ";
    }
}
