using System;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static string verifyDocument()
        {
            Console.Write("Please enter file name: ");

            string search;
            //Searches for files in the directory
            while ((search = Console.ReadLine()).Length == 0 || !File.Exists(search))
            {
                Console.Write("File does not exist: ");
            }
            //if file doesnt exist, the message is displayed. if it does, then it returns the file 'search' to main
            return search;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Document Merger\n");
            do
            {
                //calls both 
                string sample1 = verifyDocument();
                string sample2 = verifyDocument();

                string mergedSamples = sample1.Substring(0, sample1.Length - 4) + sample2;
                //adds samples names together
                StreamWriter newfile = null;
                //packages the content from both files into one 
                try
                {
                    newfile = new StreamWriter(mergedSamples);

                    int i = content(newfile, sample1);

                    i += content(newfile, sample2);

                    Console.WriteLine("{0} has been saved. The file contains {1} characters", mergedSamples);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The files could not be merged\n");
                }
                finally
                {
                    if (newfile != null)
                    {
                        newfile.Close();
                    }
                }
                Console.Write("\nDo you want to merge two more files? (y/n): ");
            }
            while (Console.ReadLine().ToLower() == "y");
        }

        static int content(StreamWriter writer, string document)
        {
            StreamReader reader = null;

            int i = 0;

            try
            {
                reader = new StreamReader(document);

                string line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    i += line.Length;

                    writer.WriteLine(line);
                }
            }

            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return i;
        }
    }
}