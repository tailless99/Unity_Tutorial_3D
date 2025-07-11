using System;
using UnityEngine;

public class BinarySearchTree : MonoBehaviour {
    /* 
     * ��ø Ŭ���� 
     * BinarySearchTree �ȿ����� ����ϴ� Ŭ��������, �ٸ� Ŭ���������� �ʿ������
     * Ŭ���� �ȿ��� �����Ѵ�.
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
        // �ʱ⿡ ��Ʈ ��尡 ����� ��
        if(node == null) return new TreeNode(V);

        if(V < node.value)
            node.left = Insert(node.left,V);
        else
            node.right = Insert(node.right, V);
        
        return node;
    }

    private void PreOrder(TreeNode node) { // ���� ��ȸ
        if (node == null) return;

        result += $"{node.value}, ";
        PreOrder(node.left);
        PreOrder(node.right);
    }

    private void InOrder(TreeNode node) { // ���� ��ȸ
        if (node == null) return;

        InOrder(node.left);
        result += $"{node.value}, ";
        InOrder(node.right);
    }

    private void PostOrder(TreeNode node) { // ���� ��ȸ
        if (node == null) return;

        PostOrder(node.left);
        PostOrder(node.right);
        result += $"{node.value}, ";
    }
}
