using System;

// Abstract class representing a unit in the processing chain
abstract class Handler
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(string document);
}

// MailRoom class
class MailRoom : Handler
{
    public override void HandleRequest(string document)
    {
        if (document.Contains("document"))
        {
            Console.WriteLine("MailRoom handles document: " + document);
        }
        else if (successor != null)
        {
            successor.HandleRequest(document);
        }
    }
}

// DepartmentA class
class DepartmentA : Handler
{
    public override void HandleRequest(string document)
    {
        if (document.Contains("DepartmentA"))
        {
            Console.WriteLine("DepartmentA handles document: " + document);
        }
        else if (successor != null)
        {
            successor.HandleRequest(document);
        }
    }
}

// DepartmentB class
class DepartmentB : Handler
{
    public override void HandleRequest(string document)
    {
        if (document.Contains("DepartmentB"))
        {
            Console.WriteLine("DepartmentB handles document: " + document);
        }
        else if (successor != null)
        {
            successor.HandleRequest(document);
        }
    }
}

// Leader class
class Leader : Handler
{
    public override void HandleRequest(string document)
    {
        Console.WriteLine("Leader handles document: " + document);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create objects representing the units in the processing chain
        Handler mailRoom = new MailRoom();
        Handler departmentA = new DepartmentA();
        Handler departmentB = new DepartmentB();
        Handler leader = new Leader();

        // Set up the processing chain
        mailRoom.SetSuccessor(departmentA);
        departmentA.SetSuccessor(departmentB);
        departmentB.SetSuccessor(leader);

        // Send the document to the processing chain
        string document = "document for DepartmentB";
        mailRoom.HandleRequest(document);

        Console.ReadLine();
    }
}
