using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using SpellChecker.Common;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SpellChecker.Cli;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var dictionary = await File.ReadAllLinesAsync("wordlist.txt");
        var exmaple = await File.ReadAllTextAsync("example.txt");

        var words = from word in exmaple.Split(' ')
                    let normalize = new string(word.ToLower().Where(c => c is >= 'a' and <= 'z').ToArray())
                    where !string.IsNullOrWhiteSpace(normalize)
                    select normalize;

        var sw = new Stopwatch();

        //GC.Collect();
        //sw.Restart();
        //Levenshtein(dictionary, words);
        //sw.Stop();
        //var levenshtein = sw.Elapsed;

        GC.Collect();
        sw.Restart();
        WagnerFischer(dictionary, words);
        sw.Stop();
        var wagnerFischer = sw.Elapsed;

        GC.Collect();
        sw.Restart();
        BkTree(dictionary, words);
        sw.Stop();
        var bkTree = sw.Elapsed;

        //Console.WriteLine("Levenshtein: " + levenshtein.ToString());
        Console.WriteLine("WagnerFischer: " + wagnerFischer.ToString());
        Console.WriteLine("BkTree: " + bkTree.ToString());
    }

    public static void Levenshtein(IEnumerable<string> dictionary, IEnumerable<string> words)
    {
        var misspelled = from word in words.Distinct()
                         where !dictionary.Contains(word)
                         select word;

        Console.WriteLine($"misspelled words: {string.Join(", ", misspelled)}");

        var editDistance = new LevenshteinDistance();

        Console.WriteLine(new string('=', Console.WindowWidth));
        foreach (var misspelling in misspelled)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine($"{misspelling}");

            var uniqueLetters = misspelling.Distinct().ToArray();
            var guesses = from possible in dictionary
                              //assume they start with the same letter 
                          where possible[0] == misspelling[0]
                          // reduce to words are similar length
                          where Math.Abs(possible.Length - misspelling.Length) < misspelling.Length - 2
                          // ensure that words share at least 3 letters
                          where uniqueLetters.Where(possible.Contains).Count() > 3
                          //calculate edit distance between words
                          let distance = editDistance.Calculate<char>(misspelling, possible)
                          let weight = Weight<char>(misspelling, possible)
                          orderby distance, weight descending
                          select new
                          {
                              possible,
                              distance,
                              weight,
                          };

            // get 10 best matches 
            var allGuesses = guesses.Take(10);

            foreach (var guess in allGuesses)
            {
                Console.WriteLine($"\t{guess.possible} ({guess.distance}, {guess.weight})");
            }
        }
    }

    public static void WagnerFischer(IEnumerable<string> dictionary, IEnumerable<string> words)
    {
        var misspelled = from word in words.Distinct()
                         where !dictionary.Contains(word)
                         select word;

        Console.WriteLine($"misspelled words: {string.Join(", ", misspelled)}");

        var editDistance = new WagnerFischerDistance();

        Console.WriteLine(new string('=', Console.WindowWidth));
        foreach (var misspelling in misspelled)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine($"{misspelling}");

            var guesses = from possible in dictionary
                          let distance = editDistance.Calculate<char>(misspelling, possible)
                          let weight = Weight<char>(misspelling, possible)
                          orderby distance, weight descending
                          select new
                          {
                              possible,
                              distance,
                              weight,
                          };

            // get 10 best matches 
            var allGuesses = guesses.Take(10);

            foreach (var guess in allGuesses)
            {
                Console.WriteLine($"\t{guess.possible} ({guess.distance}, {guess.weight})");
            }
        }
    }

    public static void BkTree(IEnumerable<string> dictionary, IEnumerable<string> words)
    {
        var tree = new BkTree<char>();
        tree.Add(dictionary.Select(w => w.AsMemory()));

        var misspelled = from word in words.Distinct()
                         where !tree.Search(word.AsMemory(), 0).Any()
                         select word;

        Console.WriteLine($"misspelled words: {string.Join(", ", misspelled)}");

        Console.WriteLine(new string('=', Console.WindowWidth));

        foreach (var misspelling in misspelled)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine($"{misspelling}");

            var guesses = from possible in tree.Search(misspelling.AsMemory(), misspelling.Length - 3)
                          let distance = possible.distance
                          let weight = Weight(misspelling, possible.value.Span)
                          orderby distance, weight descending
                          select new
                          {
                              possible,
                              distance,
                              weight,
                          };

            // get 10 best matches 
            var allGuesses = guesses.Take(10);

            foreach (var guess in allGuesses)
            {
                Console.WriteLine($"\t{guess.possible} ({guess.distance}, {guess.weight})");
            }
        }
    }

    public static double Weight<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right)
        where T : IComparable
    {
        if (left.Length == 0)
            return 0;
        if (right.Length == 0)
            return -1;

        var weight = 0d;
        for (var i = 0; i < Math.Min(left.Length, right.Length); i++)
        {
            if (left[i].CompareTo(right[i]) == 0)
                weight += 1d / (i + 1);
        }

        return weight;
    }
}
