// Class to represent "line of the future"
public class Memento
{
    public string ProcessStage { get; set; }

    // Saving the stage of the line production
    public Memento(string processStage)
    {
        ProcessStage = processStage;
    }
}

// Class to represent the imitation of line work
public class Originator
{
    private string processStage;

    public void SetProcessStage(string processStage)
    {
        Console.WriteLine($"Process stage is: {processStage}");
        this.processStage = processStage;
    }

    public string GetProcessStage()
    {
        return processStage;
    }

    // Saving current process stage to Memento object
    public Memento SaveProcessStage() { 
        return new Memento(processStage);
    }


    // Restoring process stage from Memento
    public void RestoreProcessStage(Memento memento)
    {
        processStage = memento.ProcessStage;

    }
}

// Class that saves specific stages of process
public class Caretaker
{
    private List<Memento> mementoList = new List<Memento>();

    // Adding memento objects to list
    public void AddMemento(Memento memento)
    {
        mementoList.Add(memento);
    }

    // Getting Memento object by index
    public Memento GetMemento(int index)
    {
        return mementoList[index];
    }
}



namespace Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Simulating line working process
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();
            Console.WriteLine("Total working stages");
            originator.SetProcessStage("Line working stage 1");
            originator.SetProcessStage("Line working stage 2");
            caretaker.AddMemento(originator.SaveProcessStage());
            originator.SetProcessStage("Line working stage 3");
            caretaker.AddMemento(originator.SaveProcessStage());

            originator.SetProcessStage("Line working stage 4");
            Console.WriteLine($"Current Process Stage: {originator.GetProcessStage()}");

            // Restoring previous stage
            Console.WriteLine("Ooops, machine broke");
            Console.WriteLine("Let's fix previous step");
            originator.RestoreProcessStage(caretaker.GetMemento(1));
            Console.WriteLine($"Restored to Process Stage: {originator.GetProcessStage()}");
            // Restoring more previous stage
            Console.WriteLine("Let's try another one");
            originator.RestoreProcessStage(caretaker.GetMemento(0));
            Console.WriteLine($"Restored to Process Stage: {originator.GetProcessStage()}");
        }
    }
}
