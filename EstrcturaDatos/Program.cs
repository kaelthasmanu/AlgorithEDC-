﻿using System;
using System.Runtime.CompilerServices;

namespace EstructuraDatos
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            // Binary Tree
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            
            Console.WriteLine("\nInorder traversal "
                              + "of binary tree is ");
            tree.printInorder(tree.root);
            Console.WriteLine();
            tree.printPreorder(tree.root);
            */
            //Dijkstra
            GFG t = new GFG();
            int[, ] graph = new int[, ] { 
                { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            t.dijkstra(graph, 0);

            FloydWarshallAlgo algo = new FloydWarshallAlgo();
            algo.FloydWarshall(algo.graph, 4);
        }
    }

    class Node
    {
        public int key;
        public Node left, right;

        public Node(int item)
        {
            key = item;
            left = right = null;
        }
    }

    class BinaryTree
    {
        // Root of Binary Tree
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        /* Given a binary tree, print
           its nodes in inorder*/
        public void printPreorder(Node node)
        {
            if (node == null)return;
            Console.Write(node.key + " ");
            printPreorder(node.left);
            printPreorder(node.right);
            
        }
        public void printInorder(Node node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            printInorder(node.left);

            /* then print the data of node */
            Console.Write(node.key + " ");

            /* now recur on right child */
            printInorder(node.right);
        }
    }
    class GFG {
    // A utility function to find the
    // vertex with minimum distance
    // value, from the set of vertices
    // not yet included in shortest
    // path tree
    static int V = 9;
    private int minDistance(int[] dist, bool[] sptSet)
    {
        // Initialize min value
        int min = int.MaxValue, min_index = -1;
  
        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min) {
                min = dist[v];
                min_index = v;
            }
  
        return min_index;
    }
  
    // A utility function to print
    // the constructed distance array
    void printSolution(int[] dist, int n)
    {
        Console.Write("Vertex     Distance "
                      + "from Source\n");
        for (int i = 0; i < V; i++)
            Console.Write(i + " \t\t " + dist[i] + "\n");
    }
  
    // Function that implements Dijkstra's
    // single source shortest path algorithm
    // for a graph represented using adjacency
    // matrix representation
    public void dijkstra(int[, ] graph, int src)
    {
        int[] dist = new int[V]; // The output array. dist[i]
        // will hold the shortest
        // distance from src to i
  
        // sptSet[i] will true if vertex
        // i is included in shortest path
        // tree or shortest distance from
        // src to i is finalized
        bool[] sptSet = new bool[V];
  
        // Initialize all distances as
        // INFINITE and stpSet[] as false
        for (int i = 0; i < V; i++) {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }
  
        // Distance of source vertex
        // from itself is always 0
        dist[src] = 0;
  
        // Find shortest path for all vertices
        for (int count = 0; count < V - 1; count++) {
            // Pick the minimum distance vertex
            // from the set of vertices not yet
            // processed. u is always equal to
            // src in first iteration.
            int u = minDistance(dist, sptSet);
  
            // Mark the picked vertex as processed
            sptSet[u] = true;
  
            // Update dist value of the adjacent
            // vertices of the picked vertex.
            for (int v = 0; v < V; v++)
  
                // Update dist[v] only if is not in
                // sptSet, there is an edge from u
                // to v, and total weight of path
                // from src to v through u is smaller
                // than current value of dist[v]
                if (!sptSet[v] && graph[u, v] != 0 && 
                     dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }
  
        // print the constructed distance array
        printSolution(dist, V);
    } 
    }
    class FloydWarshallAlgo
    {
        public int[,] graph = {
            { 0,   6,  cst, 11 },
            { cst, 0,   4, cst },
            { cst, cst, 0,   2 },
            { cst, cst, cst, 0 }
        };
        public const int cst = 9999;
        private static void Print(int[,] distance, int verticesCount)
        {
            Console.WriteLine("Shortest distances between every pair of vertices:");

            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    if (distance[i, j] == cst)
                        Console.Write("cst".PadLeft(7));
                    else
                        Console.Write(distance[i, j].ToString().PadLeft(7));
                }

                Console.WriteLine();
            }
        }

        public void FloydWarshall(int[,] graph, int verticesCount)
        {
            int[,] distance = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            for (int j = 0; j < verticesCount; ++j)
                distance[i, j] = graph[i, j];

            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }

            Print(distance, verticesCount);
        }
      
    }
}