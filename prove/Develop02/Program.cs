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
                    if (parts.Length >= 3)
                    {
                        string prompt = parts[0];
                        string response = parts[1];
                        DateTime date = DateTime.Parse(parts[2]);
                        entries.Add(new Entry(prompt, response, date));
                    }
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

    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date.ToString("MM/dd/yyyy")} - {Prompt}: {Response}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        // Add an entry
        journal.AddEntry("Sample Prompt", "Sample Response");

        // Display all entries
        Console.WriteLine("All Entries:");
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
