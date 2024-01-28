using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using SpellChecker.Common;

namespace SpellChecker.Cli;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var wordList = await File.ReadAllLinesAsync("wordlist.txt");

        var exmaple = @"
Once upon a tim, in a farawey land, there lived a curius littel creatur named Bubbels. 
Bubbels was alwais wanderin abot, explorin the enchannted forist that surounded his hobbit. 
One day, as he skipd through the tall gras, he stumbld upon a mystirious glowin rock.

Intriged by the shiny object, Bubbels reachd out and tuched it with his tinie paws. Sudnly, 
a magical portal opend up, transportin him to a whimsical realm filld with wondurs and 
fantastik beings. Bubbels was amazd at the colorfull sights and odd creatures that inhabitd 
this new world.

He encounterd a mischievus gobelin who offerd him a magik wand in exchang for a baskit of 
glemrinberries. Bubbels, not knowin what a glemrinberry was, noddd his hed enthusiasstically 
and set off on a quest to find the elusive fruit.

As he venturd deeper into the enchannted forist, Bubbels encountred talking treess, gigglin 
fairies, and a friendly dragun who enjoyd tellin riddels. Each misadventur brought him closer 
to his goal of collectin glemrinberries for the gobelin.

Even tho Bubbels struggld with the odd spellins of the forist creaturs, he managd to 
communicat and make new frends along the way. Eventually, he returnd to the gobelin with a 
baskit full of the glowin glemrinberries.

The gobelin, true to his word, gave Bubbels the magik wand. With a flick of his tinie wrist, 
Bubbels casted a spell that transportd him back to his own hobbit. As he sat in his cozy 
burro, he reflectd on the magik adventure and the joy of makin new frends, no matter how 
stranjely they spellt their words.

And so, Bubbels continu'd to explore the enchannted forist, embracin the misspelled words 
and whimsicality that filld his magical world.";

        var words = from word in exmaple.Split(' ')
                    let normalize = new string(word.ToLower().Where(c => c >= 'a' && c <= 'z').ToArray())
                    where !string.IsNullOrWhiteSpace(normalize)
                    select normalize;

        var misspelled = from word in words.Distinct()
                         where !wordList.Contains(word)
                         select word;

        Console.WriteLine($"misspelled words: {string.Join(", ", misspelled)}");

        var suggestions = from word in misspelled //.Take(1)
                          let uniqueLetters = word.Distinct().ToArray()
                          let guesses = (from possible in wordList

                                         where Math.Abs(possible.Length - word.Length) < word.Length - 2

                                         /*
                                        faraway (1)
                                        faraday (2)
                                        caraway (2)
                                        thrawed (3)
                                        scrawly (3)
                                         */
                                         //where word.Where(possible.Contains).Count() > 4

                                         // /*
                                         //faraway (1)
                                         //farrowed (3)
                                         //farewell (3)
                                         //frayed (3)
                                         //forayer (3)
                                         // */
                                         where uniqueLetters.Where(possible.Distinct().Contains).Count() > 3

                                         let distance = LevenshteinDistance.Calculate<char>(word, possible)
                                         where distance < word.Length
                                         select new
                                         {
                                             possible,
                                             distance
                                         }).AsParallel().OrderBy(p => p.distance).Take(5).ToArray()
                          select new
                          {
                              word,
                              guesses = guesses.Take(5).ToArray()
                          };

        Console.WriteLine(new string('=', Console.WindowWidth));
        foreach (var suggestion in suggestions)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine($"{suggestion.word}");

            foreach (var guess in suggestion.guesses)
            {
                Console.WriteLine($"\t{guess.possible} ({guess.distance})");
            }
        }
    }
}
