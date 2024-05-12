using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        entries.Add(new Entry(prompt, response));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Prompt}|{entry.Response}|{entry.Date.ToString("MM/dd/yyyy")}");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    entries.Add(new Entry { Prompt = parts[0], Response = parts[1], Date = DateTime.Parse(parts[2]) });
                }
            }
            Console.WriteLine("Journal loaded from file.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }
    }
}

class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public DateTime Date { get; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }

    public Entry() { }

    public override string ToString()
    {
        return $"{Date.ToString("MM/dd/yyyy")} - {Prompt}: {Response}";
    }
}

class PromptGenerator
{
    private string[] prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GenerateRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Length);
        return prompts[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Random Prompt:");
        string randomPrompt = promptGenerator.GenerateRandomPrompt();
        Console.WriteLine(randomPrompt);

        // Add an entry
        journal.AddEntry(randomPrompt, "Sample response");

        // Display all entries
        Console.WriteLine("\nAll Entries:");
        journal.DisplayEntries();

        // Save entries to a file
        string filename = "journal.txt";
        journal.SaveToFile(filename);

        // Load entries from the file
        journal.LoadFromFile(filename);

        // Display loaded entries
        Console.WriteLine("\nLoaded Entries:");
        journal.DisplayEntries();
    }
}
