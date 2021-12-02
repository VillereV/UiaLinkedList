// // See https://aka.ms/new-console-template for more information
// Description
// Implement a linked list that stores integers.
//
// Start by reading and understanding the general description of a linked list:
// https://en.wikipedia.org/wiki/Linked_listLenker til en ekstern side.
//
// Create a class for the list and a class for the node. You must then figure out how to add a new node when the user
// calls push_back(), and how to remove a node when the user calls remove().
// Description
// Implement a linked list that stores integers.
//
// Start by reading and understanding the general description of a linked list:
// https://en.wikipedia.org/wiki/Linked_listLenker til en ekstern side.
//
// Create a class for the list and a class for the node. You must then figure out how to add a new node when the user
// calls push_back(), and how to remove a node when the user calls remove().
//
// Limitations
// Each node is connected to the next node with pointers. The following are not allowed in this assignment:
//
// arrays (for the list itself, OK elsewhere)
// std::vector
// std::list
// std::map
// (any other std:: container)
// Specification
// The list class must contain the following functions:
//
// void push_back(const int value)
// Add a value to the back of your list
// size_t size()
// Get the item count
// int& at(size_t index)
// Retrieve item by index
// void remove(size_t index)
// Remove item at specified index
// Areas of interest: Pointers, classes, new/delete operators
//
// Application UI
// Once you have implemented your linked list write an application that uses the list with the following menu.
//
// The user types a number and presses enter to choose:
//
// Add integer (asks for a number and adds it to the list)
// Show integer at index (ask for index)
// Remove integer at index (ask for index)
// Print information (see below)
// Exit
// Note: Indexes start from 0.
//
// Expected output with no integers:
// List contains no integers
//
// Expected output (from 2):
// Integer at index 5: 42
//
// Expected output (from 4):
// List contains 4 integers: 1 2 3 4
//
// Test locally
// see Local testing with Docker under Assignments.
//
// Test the solution on your own computer. You can fix your code and retest as many times as you want.
//
// Deliver and test in Bamboo
// See Delivery and Bamboo testing under Assignments.
//
// Finally deliver and test the solution in Bamboo. This is what updates your score in Canvas which is the score I can see. You can test as many times as you want here as well up until the final deadline.
// Limitations
// Each node is connected to the next node with pointers. The following are not allowed in this assignment:
//
// arrays (for the list itself, OK elsewhere)
// std::vector
// std::list
// std::map
// (any other std:: container)
// Specification
// The list class must contain the following functions:
//
// void push_back(const int value)
// Add a value to the back of your list
// size_t size()
// Get the item count
// int& at(size_t index)
// Retrieve item by index
// void remove(size_t index)
// Remove item at specified index
// Areas of interest: Pointers, classes, new/delete operators
//
// Application UI
// Once you have implemented your linked list write an application that uses the list with the following menu.
//
// The user types a number and presses enter to choose:
//
// Add integer (asks for a number and adds it to the list)
// Show integer at index (ask for index)
// Remove integer at index (ask for index)
// Print information (see below)
// Exit
// Note: Indexes start from 0.
//
// Expected output with no integers:
// List contains no integers
//
// Expected output (from 2):
// Integer at index 5: 42
//
// Expected output (from 4):
// List contains 4 integers: 1 2 3 4
//
// Test locally
// see Local testing with Docker under Assignments.
//
// Test the solution on your own computer. You can fix your code and retest as many times as you want.
//
// Deliver and test in Bamboo
// See Delivery and Bamboo testing under Assignments.
//
// Finally deliver and test the solution in Bamboo. This is what updates your score in Canvas which is the score I can see. You can test as many times as you want here as well up until the final deadline.
// Console.WriteLine("Hello, World!");

using System;
using System.Text;


namespace UiaLinkedList
{
  public class HovedKlassen
  {

    public static void Main(string[] args)
    {
      Console.WriteLine("Programmet starter");
      LinkedList myLinkedList = new LinkedList();
      string? userInput;
      while (true)
      {
        Console.WriteLine("Add to list with command 'list -a {your number}' i.e. 'list -a 17'");
        Console.WriteLine("View list with command 'list -v'");
        Console.WriteLine("Delete an item in list at index with command 'list -d {index to delete}' i.e. 'list -d {index to delete}'");
        Console.Write("Enter your command: ");
        userInput = Console.ReadLine();
        if (string.IsNullOrEmpty(userInput)) break;

        EvaluateUserInput(userInput, myLinkedList);

        Console.WriteLine();
        Console.WriteLine();
      }
      Console.WriteLine("Programmet stopper");
    }

    private static void EvaluateUserInput(string userInput, LinkedList list)
    {
      string[] splitted = userInput.Split(' ');
      Console.WriteLine(splitted.Length);

      if (
        splitted.Length is < 2 or > 3
        || splitted[0] != "list"
        // || splitted[1].Length != 2
        // || "adv".Contains(splitted[1][1])
      )
      {
        Console.WriteLine("Unknown command");
        return;
      }

      string command = splitted[1];
      switch (command)
      {
        case "-a":
          int userInputNumber = int.Parse(splitted[2]);
          list.PushBack(userInputNumber);
          Console.WriteLine($"Added number ${userInputNumber}");
          break;
        case "-d":
          int userInputIndex = int.Parse(splitted[2]);
          list.RemoveAtIndex(userInputIndex);
          Console.WriteLine($"Removed at index ${userInputIndex}");
          break;
        case "-v":
          DisplayList(list);
          break;
      }
      return;
    }

    private static void DisplayList(LinkedList list)
    {
      int[] intArray = list.GetListAsArray();
      string arrayAsString = ItemsInArrayToStringWithSpace(intArray);
      Console.WriteLine($"Your list: {arrayAsString}");
    }

    private static string ItemsInArrayToStringWithSpace(int[] array)
    {
      return string.Join(' ', array);
    }
  }

  /// <summary>
  /// NODE KLASSEN
  /// Hver node har et tall og peker på hvilken node som er den neste i rekken
  /// </summary>
  public class Node
  {
    public int Number;
    public Node? Next; // spørsmålstegn betyr at den kan være null
  }

  /// <summary>
  /// linked list klassen med metoder(funksjoner) som legger til, fjerner fra listen, returner lengden på listen
  /// og returnerer alle tallene som et Array
  ///
  /// eksempel på linked list med tre noder. den siste noden sin neste(Next) er null og peker ikke på noen andre.
  /// node -> node -> node -> null
  /// </summary>
  public class LinkedList
  {
    private Node? _head;

    /// <summary>
    /// Lengden på listen
    /// </summary>
    public int Size
    {
      get
      {
        int mySize = 0;
        Node? currentNode = _head;

        // så lenge currentnode ikke er null går loopen videre og vi øker lengden(mySize) med 1 for hver runde
        while (currentNode != null)
        {
          mySize++;
          currentNode = currentNode.Next;
        }

        return mySize;
      }
    }

    /// <summary>
    /// Lager en ny node, legger tallet på noden sitt Number, legger den til på slutten av listen
    /// </summary>
    /// <param name="newNumber"></param>
    public void PushBack(int newNumber)
    {
      // Lager ny node
      Node myNode = new Node();
      myNode.Number = newNumber;

      // Sjekker om hodet(begynnelsen) er tomt. Hvis hodet er tomt(null) finnes det ingen elementer i listen, og
      // vi sier at hodet er den nye noden vi laget.
      if (_head is null)
      {
        _head = myNode;
        return;
      }

      int sizeOfLinkedList = Size;

      // finner den siste noden i den eksisterende listen
      Node lastNode = GetNodeAtIndex(sizeOfLinkedList - 1);

      // den siste noden sin neste node blir den nye noden vi laget
      lastNode.Next = myNode;
    }

    /// <summary>
    /// Fjerner et element i listen på en spesifikk index
    /// </summary>
    /// <param name="index"></param>
    public void RemoveAtIndex(int index)
    {
      // 1. finner noden bak valgte index
      // 2. hvis indeksen er 0, finnes ingen foran indeksen og det nye hodet (_head) blir noden den som er på index 1
      // 3. Finner noden foran indexen
      // 4. kobler de sammen

      Node nodeOnIndexAfter = GetNodeAtIndex(index + 1);
      if (index == 0)
      {
        _head = nodeOnIndexAfter;
        return;
      }

      Node nodeOnIndexBefore = GetNodeAtIndex(index - 1);

      nodeOnIndexBefore.Next = nodeOnIndexAfter;
    }

    /// <summary>
    /// returnerer nummer til noden på en valgt index
    /// </summary>
    /// <param name="Index"></param>
    /// <returns></returns>
    public int GetNumberAtIndex(int index)
    {
      // 1. sjekker om det er valid index
      // 2. finner noden på indexen
      // 3. returnerer tallet til noden



      // kaster feilmelding hvis indeksen er utenfor lengden på linked-listen
      if (index > Size -1)
      {
        throw new IndexOutOfRangeException();
      }

      // finner noden som er etterspurt
      Node nodeAtAnIndex = GetNodeAtIndex(index);

      // returnerer noden sitt nummer (int)
      return nodeAtAnIndex.Number;
    }

    /// <summary>
    /// returnerer en node på en valgt indeks
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    private Node GetNodeAtIndex(int index)
    {
      int currentIndex = 0;
      Node? currentNode = _head;

      while (index < currentIndex)
      {
        currentIndex++;

        // går ut av loopen hvis nodene er null
        if (currentNode is null || currentNode.Next is null) break;

        // setter nåværende node til den neste noden
        currentNode = currentNode.Next;
      }

      // Kaster feilmelding hvis noden er null fordi det ikke finnes noe på indexen
      if (currentNode is null)
      {
        throw new IndexOutOfRangeException();
      }

      // returner (gir tilbake) noden vi har funnet
      return currentNode;
    }

    /// <summary>
    /// gir tilbake et array med verdiene i linked list
    /// </summary>
    /// <returns></returns>
    public int[] GetListAsArray()
    {
      int lengthOfLinkedList = Size;

      int[] myArray = new int[lengthOfLinkedList];
      Node? currentNode = _head;

      for (int i = 0; i < lengthOfLinkedList; i++)
      {
        if (currentNode is null)
        {
          throw new Exception("ERROR ERROR Something terrible went wrong");
        }
        myArray[i] = currentNode.Number;
        currentNode = currentNode.Next;
      }

      return myArray;
    }
  }
}
